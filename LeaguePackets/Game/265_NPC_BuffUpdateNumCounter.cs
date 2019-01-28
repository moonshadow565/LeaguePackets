
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_BuffUpdateNumCounter : GamePacket // 0x109
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateNumCounter;
        public byte BuffSlot { get; set; }
        public int Counter { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.BuffSlot = reader.ReadByte();
            this.Counter = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteInt32(Counter);
        }
    }
}
