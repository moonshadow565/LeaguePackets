using System;
using System.IO;
using LeaguePackets;
using LeaguePackets.Common;
using LeaguePackets.GamePackets;
using LeaguePackets.CommonData;
using LeaguePackets.PayloadPackets;
using Newtonsoft.Json;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;

namespace LeaguePacketsSender
{
    public static class Commands
    {
        public static string LeaveVision(LeagueServer server, ClientID client, string args)
        {
            var packet = new OnLeaveVisiblityClient();
            packet.SenderNetID = (NetID)0x40000001;
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "LeaveVision?";
        }

        public static string EnterVision(LeagueServer server, ClientID client, string args)
        {
            var packet = new OnEnterVisiblityClient();
            packet.SenderNetID = (NetID)0x40000001;
            var visibility = new VisibilityDataAIHero();
            visibility.MovementData = new MovementDataStop
            {
                Position = new Vector2(26, 280),
                Forward = new Vector2(26, 280),
            };
            visibility.MovementSyncID = 14;
            packet.VisibilityData = visibility;
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "EnterVision?";
        }

        public static string AddItem(LeagueServer server, ClientID client, string args)
        {
            var packet = new BuyItemAns();
            packet.SenderNetID = (NetID)0x40000001;
            packet.Item.ItemID = (ItemID)3100;
            packet.Item.ItemsInSlot = 1;
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "AddItem!";
        }

        public static string TestRep(LeagueServer server, ClientID client, string args)
        {
            var packet = new OnReplication();
            packet.SyncID = (uint)Environment.TickCount;
            var data = new ReplicationData()
            {
                UnitNetID = (NetID)0x40000001,
            };
            byte[] buffer;
            using(var stream = new MemoryStream())
            {
                using (var writer = new PacketWriter(stream, true))
                {
                    writer.WritePackedFloat(333.0f);
                    writer.WritePackedFloat(123.0f);
                }
                buffer = new byte[stream.Length];
                Buffer.BlockCopy(stream.GetBuffer(), 0, buffer, 0, buffer.Length);
            }

            BitArray array = new BitArray(32);
            array.Set(0, true);
            array.Set(1, true);

            data.Data[3] = new Tuple<BitArray, byte[]>(array, buffer);

            packet.ReplicationData = new List<ReplicationData>()
            {
                data
            };
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "AddItem!";
        }

        public static string Test002(LeagueServer server, ClientID client, string args)
        {
            var packet = new S2C_DisplayLocalizedTutorialChatText();
            packet.SenderNetID = (NetID)0x40000001;
            packet.Message = "hello!";
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "Test!";
        }

        public static string Test013(LeagueServer server, ClientID client, string args)
        {
            var packet = new S2C_ReplaceObjectiveText();
            packet.SenderNetID = (NetID)0x40000001;
            packet.TextID = "hello!";
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "Test!";
        }

        public static string Test016(LeagueServer server, ClientID client, string args)
        {
            var packet = new UnitAddEXP();
            packet.TargetNetID = (NetID)0x40000001;
            packet.ExpAmmount = 100.0f;
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "Test!";
        }

        public static string TestBatch(LeagueServer server, ClientID client, string args)
        {
            var batched = new BatchPacket();
            var packet1 = new UnitAddEXP();
            packet1.TargetNetID = (NetID)0x40000001;
            packet1.ExpAmmount = 100.0f;

            var packet2 = new BuyItemAns();
            packet2.SenderNetID = (NetID)0x40000001;
            packet2.Item.ItemID = (ItemID)3100;
            packet2.Item.ItemsInSlot = 1;

            var packet3 = new BuyItemAns();
            packet3.SenderNetID = (NetID)0x40000001;
            packet3.Item.ItemID = (ItemID)3025;
            packet3.Item.ItemsInSlot = 1;
            packet3.Item.Slot = 2;

            batched.Packets.Add(packet1);
            batched.Packets.Add(packet2);
            batched.Packets.Add(packet3);

            server.SendEncrypted(client, ChannelID.Broadcast, batched);
            return "Batched!";
        }
    }
}
