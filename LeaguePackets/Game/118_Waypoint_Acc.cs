
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class Waypoint_Acc : GamePacket // 0x77
    {
        public override GamePacketID ID => GamePacketID.Waypoint_Acc;
        public int SyncID { get; set; }
        public byte TeleportCount { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadInt32();
            this.TeleportCount = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SyncID);
            writer.WriteByte(TeleportCount);
        }
    }
}
