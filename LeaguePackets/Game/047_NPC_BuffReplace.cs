
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_BuffReplace : GamePacket // 0x30
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffReplace;
        public byte BuffSlot { get; set; }
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public uint CasterNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.BuffSlot = reader.ReadByte();
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            this.CasterNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteFloat(RunningTime);
            writer.WriteFloat(Duration);
            writer.WriteUInt32(CasterNetID);
        }
    }
}
