using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SynchVersionC2S : GamePacket // 0xBD
    {
        public override GamePacketID ID => GamePacketID.SynchVersionC2S;
        public ClientID ClientIDNet { get; set; }
        public string Version { get; set; } = "";
        public SynchVersionC2S(){}

        public SynchVersionC2S(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ClientIDNet = reader.ReadClientID();
            this.Version = reader.ReadFixedStringLast(256);
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientIDNet);
            writer.WriteFixedStringLast(Version, 256);
        }
    }
}
