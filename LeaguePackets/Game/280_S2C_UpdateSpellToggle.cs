
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UpdateSpellToggle : GamePacket // 0x118
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateSpellToggle;
        public int SpellSlot { get; set; }
        public bool ToggleValue { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SpellSlot = reader.ReadInt32();

            byte bitfield = reader.ReadByte();
            this.ToggleValue = (bitfield & 0x01) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SpellSlot);

            byte bitfield = 0;
            if (ToggleValue)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
