using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Waypoint_Acc : GamePacket // 0x77
    {
        public override GamePacketID ID => GamePacketID.Waypoint_Acc;
        public int SyncID { get; set; }
        public byte TeleportCount { get; set; }
        public static Waypoint_Acc CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new Waypoint_Acc();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.SyncID = reader.ReadInt32();
            result.TeleportCount = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SyncID);
            writer.WriteByte(TeleportCount);
        }
    }
}
