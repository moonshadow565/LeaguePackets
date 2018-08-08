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
        public Waypoint_Acc(){}

        public Waypoint_Acc(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SyncID = reader.ReadInt32();
            this.TeleportCount = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SyncID);
            writer.WriteByte(TeleportCount);
        }
    }
}
