using System;
using System.IO;
using LeaguePackets;

using LeaguePackets.Game;
using LeaguePackets.Game.Common;
using LeaguePackets.LoadScreen;
using Newtonsoft.Json;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;

namespace LeaguePacketsSender
{
    public static class Commands
    {
        public static string LeaveVision(LeagueServer server, int client, string args)
        {
            var packet = new OnLeaveVisiblityClient();
            packet.SenderNetID = 0x40000001;
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "LeaveVision?";
        }

        public static string EnterVision(LeagueServer server, int client, string args)
        {
            var packet = new OnEnterVisiblityClient();
            packet.SenderNetID = 0x40000001;
            packet.MovementData = new MovementDataStop
            {
                Position = new Vector2(26, 280),
                Forward = new Vector2(26, 280),
                SyncID = 14
            };
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "EnterVision?";
        }

        public static string AddItem(LeagueServer server, int client, string args)
        {
            var packet = new BuyItemAns();
            packet.SenderNetID = 0x40000001;
            packet.Item.ItemID = 3100;
            packet.Item.ItemsInSlot = 1;
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "AddItem!";
        }

        public static string Speed(LeagueServer server, int client, string args)
        {
            if(string.IsNullOrEmpty(args))
            {
                return "Missing speed value!";
            }
            float value = float.Parse(args);
            byte[] buffer = BitConverter.GetBytes(value);

            var packet = new OnReplication();
            packet.SyncID = (uint)Environment.TickCount;
            var data = new ReplicationData()
            {
                UnitNetID = 0x40000001,
            };
            data.Data[3] = new Tuple<uint, byte[]>(1 << 10, buffer);

            packet.ReplicationData = new List<ReplicationData>()
            {
                data
            };
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "Speed!";
        }

        public static string AddGold(LeagueServer server, int client, string args)
        {
            if (string.IsNullOrEmpty(args))
            {
                return "Missing speed value!";
            }
            float value = float.Parse(args);
            byte[] buffer = BitConverter.GetBytes(value);

            var packet = new OnReplication();
            packet.SyncID = (uint)Environment.TickCount;
            var data = new ReplicationData()
            {
                UnitNetID = 0x40000001,
            };
            data.Data[0] = new Tuple<uint, byte[]>(1, buffer);
            packet.ReplicationData = new List<ReplicationData>()
            {
                data
            };
            server.SendEncrypted(client, ChannelID.Broadcast, packet);


            var packet2 = new UnitAddGold
            {
                GoldAmmount = value,
                TargetNetID = 0x40000001,
            };
            server.SendEncrypted(client, ChannelID.Broadcast, packet2);
            return "Gold Added!";
        }

        public static string TestRep(LeagueServer server, int client, string args)
        {
            var packet = new OnReplication();
            packet.SyncID = (uint)Environment.TickCount;
            var data = new ReplicationData()
            {
                UnitNetID = 0x40000001,
            };

            using (var writer = new ByteWriter())
            {
                writer.WritePackedFloat(333.0f);
                writer.WritePackedFloat(123.0f);
                data.Data[3] = new Tuple<uint, byte[]>((1 << 0) | (1 << 1), writer.GetBytes());
            }

            packet.ReplicationData = new List<ReplicationData>()
            {
                data
            };
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "TestRep!";
        }

        public static string Test002(LeagueServer server, int client, string args)
        {
            var packet = new S2C_DisplayLocalizedTutorialChatText();
            packet.SenderNetID = 0x40000001;
            packet.Message = "hello!";
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "Test S2C_DisplayLocalizedTutorialChatText!";
        }

        public static string Test013(LeagueServer server, int client, string args)
        {
            var packet = new S2C_ReplaceObjectiveText();
            packet.SenderNetID = 0x40000001;
            packet.TextID = "hello!";
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "Test S2C_ReplaceObjectiveText!";
        }

        public static string Test016(LeagueServer server, int client, string args)
        {
            var packet = new UnitAddEXP();
            packet.TargetNetID = 0x40000001;
            packet.ExpAmmount = 100.0f;
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "Test UnitAddEXP!";
        }

        public static string TestUndo(LeagueServer server, int client, string args)
        {
            var packet = new S2C_SetUndoEnabled();
            packet.UndoStackSize = 2;
            server.SendEncrypted(client, ChannelID.Broadcast, packet);
            return "Test S2C_SetUndoEnabled!";
        }

        public static string TestBatch(LeagueServer server, int client, string args)
        {
            var batched = new Batched();
            var packet1 = new UnitAddEXP();
            packet1.TargetNetID = 0x40000001;
            packet1.ExpAmmount = 100.0f;

            var packet2 = new BuyItemAns();
            packet2.SenderNetID = 0x40000001;
            packet2.Item.ItemID = 3100;
            packet2.Item.ItemsInSlot = 1;

            var packet3 = new BuyItemAns();
            packet3.SenderNetID = 0x40000001;
            packet3.Item.ItemID = 3025;
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
