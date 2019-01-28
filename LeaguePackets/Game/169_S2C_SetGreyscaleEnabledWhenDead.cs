
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetGreyscaleEnabledWhenDead : GamePacket // 0xA9
    {
        public override GamePacketID ID => GamePacketID.S2C_SetGreyscaleEnabledWhenDead;
        public bool Enabled { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.Enabled = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (Enabled)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
