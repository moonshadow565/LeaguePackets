
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class CHAR_SetCooldown : GamePacket // 0x85
    {
        public override GamePacketID ID => GamePacketID.CHAR_SetCooldown;
        public byte Slot { get; set; }
        public bool PlayVOWhenCooldownReady { get; set; }
        public bool IsSummonerSpell { get; set; }

        public float Cooldown { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.Slot = (byte)(bitfield & 0x3F);
            this.IsSummonerSpell = (bitfield & 0x40) != 0;

            this.Cooldown = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(Slot & 0x3F);
            if (IsSummonerSpell)
                bitfield |= 0x40;
            writer.WriteByte(bitfield);

            writer.WriteFloat(Cooldown);
        }
    }
}
