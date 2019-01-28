
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_SetAutocast : GamePacket // 0x1F
    {
        public override GamePacketID ID => GamePacketID.NPC_SetAutocast;
        public byte Slot { get; set; }
        public byte CritSlot { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Slot = reader.ReadByte();
            this.CritSlot = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(CritSlot);
        }
    }
}
