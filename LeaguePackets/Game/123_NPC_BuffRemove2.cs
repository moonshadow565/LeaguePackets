
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_BuffRemove2 : GamePacket // 0x7B
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffRemove2;
        public byte BuffSlot { get; set; }
        public uint BuffNameHash { get; set; }
        public float RunTimeRemove { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.BuffSlot = reader.ReadByte();
            this.BuffNameHash = reader.ReadUInt32();
            this.RunTimeRemove = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteUInt32(BuffNameHash);
            writer.WriteFloat(RunTimeRemove);
        }
    }
}
