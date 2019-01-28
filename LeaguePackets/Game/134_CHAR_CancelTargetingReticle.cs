
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class CHAR_CancelTargetingReticle : GamePacket // 0x86
    {
        public override GamePacketID ID => GamePacketID.CHAR_CancelTargetingReticle;
        public byte SpellSlot { get; set; }
        //TOOD: not sure what to name the bool
        public bool ResetSpecified { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            this.SpellSlot = reader.ReadByte();

            byte bitfield = reader.ReadByte();
            this.ResetSpecified = (bitfield & 0x01) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(SpellSlot);

            byte bitfield = 0;
            if (ResetSpecified)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
