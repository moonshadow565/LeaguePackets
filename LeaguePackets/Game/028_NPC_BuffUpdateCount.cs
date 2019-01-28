
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_BuffUpdateCount : GamePacket // 0x1C
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateCount;
        public byte BuffSlot { get; set; }
        public byte Count { get; set; }
        public float Duration { get; set; }
        public float RunningTime { get; set; }
        public uint CasterNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.BuffSlot = reader.ReadByte();
            this.Count = reader.ReadByte();
            this.Duration = reader.ReadFloat();
            this.RunningTime = reader.ReadFloat();
            this.CasterNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteByte(Count);
            writer.WriteFloat(Duration);
            writer.WriteFloat(RunningTime);
            writer.WriteUInt32(CasterNetID);
        }
    }
}
