using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENet;
using LeaguePackets;


namespace LeaguePacketsSender
{
    public class LeagueDisconnectedEventArgs
    {
        public int ClientID { get; private set; }
        public string EventName => "disconnected";
        public LeagueDisconnectedEventArgs(int clientID)
        {
            ClientID = clientID;
        }
    }

    public class LeagueConnectedEventArgs
    {
        public int ClientID { get; private set; }
        public string EventName => "connected";
        public LeagueConnectedEventArgs(int clientID)
        {
            ClientID = clientID;
        }
    }

    public class LeaguePacketEventArgs : EventArgs
    {
        public string EventName => "packet";
        public int ClientID { get; set; }
        public ChannelID ChannelID { get; private set; }
        public BasePacket Packet { get; private set; }
        public LeaguePacketEventArgs(int clientID, ChannelID channel, BasePacket packet)
        {
            ClientID = clientID;
            ChannelID = channel;
            Packet = packet;
        }
    }

    public class LeagueBadPacketEventArgs : EventArgs
    {
        public string EventName => "badpacket";
        public int ClientID { get; set; }
        public ChannelID ChannelID { get; private set; }
        public byte[] RawData { get; private set; }
        public Exception Exception { get; private set; }
        public LeagueBadPacketEventArgs(int clientID, ChannelID channel, byte[] rawData, Exception exception)
        {
            ClientID = clientID;
            ChannelID = channel;
            RawData = rawData;
            Exception = exception;
        }
    }


    public static class ByteExtension 
    {
        public static void PrintHex(this byte[] data, int perline = 8)
        {
            for (int i = 0; i < data.Length; i += perline)
            {
                for (int c = i; c < (i + perline) && c < data.Length; c++)
                {
                    Console.Write("{0:X2} ", (uint)data[c]);
                }
                Console.Write("\r\n");
            }
        }
    }

    public static class PeerExtension
    {
        public static bool Send(this Peer peer, ChannelID channel, byte[] data,
                                bool reliable = true, bool unsequenced = false)
        {
            var packet = new ENet.Packet();
            var flags = PacketFlags.None;
            if(reliable)
            {
                flags |= PacketFlags.Reliable;
            }
            if(unsequenced)
            {
                flags |= PacketFlags.Unsequenced;
            }
            packet.Create(data, 0, data.Length, flags);
            return peer.Send((byte)channel, packet);
        }
    }


    public class LeagueServer
    {
        private Host _host;
        private BlowFish _blowfish;
        private Dictionary<int, Peer> _peers = new Dictionary<int, Peer>();
        public event EventHandler<LeagueDisconnectedEventArgs> OnDisconnected;
        public event EventHandler<LeagueConnectedEventArgs> OnConnected;
        public event EventHandler<LeaguePacketEventArgs> OnPacket;
        public event EventHandler<LeagueBadPacketEventArgs> OnBadPacket;

        public LeagueServer(Address address, byte[] key, List<int> cids)
        {
            _host = new Host();
            _blowfish = new BlowFish(key);
            _host.Create(address,32, 8, 0, 0);
            foreach(var cid in cids)
            {
                _peers[cid] = null;
            }
        }

        private bool SendEncrypted(Peer peer, ChannelID channel, BasePacket packet,
                                bool reliable = true, bool unsequenced = false)
        {
            var data = packet.GetBytes();
            data = _blowfish.Encrypt(data);
            return peer.Send(channel, data, reliable, unsequenced);
        }

        public bool SendEncrypted(int client, ChannelID channel, BasePacket packet,
                                bool reliable = true, bool unsequenced = false)
        {
            if(!_peers.ContainsKey(client))
            {
                //TODO: throw here?
                return false;
            }
            var peer = _peers[client];
            if(peer == null)
            {
                //TODO: throw here?
                return false;
            }
            return SendEncrypted(_peers[client], channel, packet, reliable, unsequenced);
        }



        public void RunOnce()
        {
            while (_host.Service(0, out Event eevent) != 0)
            {
                switch (eevent.Type)
                {
                    case EventType.None:
                        break;
                    case EventType.Connect:
                        eevent.Peer.Mtu = 996;
                        break;
                    case EventType.Disconnect:
                        if((uint)eevent.Peer.UserData != 0)
                        {
                            var cid = (int)eevent.Peer.UserData;
                            _peers[cid] = null;
                            OnDisconnected(this, new LeagueDisconnectedEventArgs(cid));
                        }
                        break;
                    case EventType.Receive:
                        if((uint)eevent.Peer.UserData == 0)
                        {
                            if(eevent.ChannelID != (byte)ChannelID.Default)
                            {
                                eevent.Peer.Disconnect(0);
                            }
                            else
                            {
                                HandleAuth(eevent.Peer, eevent.Packet);
                            }
                        }
                        else
                        {
                            HandlePacketParse((ChannelID)eevent.ChannelID, eevent.Peer, eevent.Packet);
                        }
                        break;
                }
            }
        }

        private void HandlePacketParse(ChannelID channel, Peer peer, Packet rawPacket)
        {
            var cid = (int)peer.UserData;
            var rawData = rawPacket.GetBytes();
            rawData = _blowfish.Decrypt(rawData);
            try
            {
                var packet = BasePacket.Create(rawData, channel);
                OnPacket(this, new LeaguePacketEventArgs(cid, channel, packet));
            }
            catch (NotImplementedException exception)
            {
                OnBadPacket(this, new LeagueBadPacketEventArgs(cid, channel, rawData, exception));
            }
            catch (IOException exception)
            {
                OnBadPacket(this, new LeagueBadPacketEventArgs(cid, channel, rawData, exception));
            }
        }


        private void HandleAuth(Peer peer, Packet rawPacket)
        {
            var rawData = rawPacket.GetBytes();
            try
            {
                KeyCheckPacket clientAuthPacket = KeyCheckPacket.Create(rawData);
                if(_blowfish.Encrypt((ulong)clientAuthPacket.PlayerID) != clientAuthPacket.CheckSum)
                {
                    Console.WriteLine($"Got bad checksum({clientAuthPacket.CheckSum} for {clientAuthPacket.PlayerID})");
                    peer.Disconnect(0);
                    return;
                }
                var cid = (int)clientAuthPacket.PlayerID;
                if(!_peers.ContainsKey(cid))
                {
                    Console.WriteLine($"Client id: {cid} not in allowed cid list!");
                    peer.Disconnect(0);
                    return;
                }
                if(_peers[cid] != null)
                {
                    Console.WriteLine($"Client already connected!");
                    peer.Disconnect(0);
                    return;
                }
                peer.UserData = (IntPtr)cid;
                _peers[cid] = peer;

                KeyCheckPacket serverAuthPacket = new KeyCheckPacket();;
                serverAuthPacket.ClientID = cid;
                serverAuthPacket.PlayerID = clientAuthPacket.PlayerID;
                serverAuthPacket.VersionNumber = clientAuthPacket.VersionNumber;
                serverAuthPacket.CheckSum = clientAuthPacket.CheckSum;
                SendEncrypted(peer, ChannelID.Default, serverAuthPacket);
                OnConnected(this, new LeagueConnectedEventArgs(cid));
            }
            catch(IOException)
            {
                Console.WriteLine("Failed to read/write KeyCheck packet!");
                rawData.PrintHex();
                peer.Disconnect(0);
                return;
            }
        }
    }
}
