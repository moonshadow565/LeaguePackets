
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
        public float MaxCooldownForDisplay { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Slot = reader.ReadByte();

            byte bitfield = reader.ReadByte();
            this.PlayVOWhenCooldownReady = (bitfield & 0x01) != 0;
            this.IsSummonerSpell = (bitfield & 0x02) != 0;

            this.Cooldown = reader.ReadFloat();
            this.MaxCooldownForDisplay = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);

            byte bitfield = 0;
            if (PlayVOWhenCooldownReady)
                bitfield |= 0x01;
            if (IsSummonerSpell)
                bitfield |= 0x02;
            writer.WriteByte(bitfield);

            writer.WriteFloat(Cooldown);
            writer.WriteFloat(MaxCooldownForDisplay);
        }
    }
}
