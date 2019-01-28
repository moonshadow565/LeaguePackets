
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetHoverIndicatorEnabled : GamePacket // 0xF6
    {
        public override GamePacketID ID => GamePacketID.S2C_SetHoverIndicatorEnabled;
        public bool Enabled { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.Enabled = (bitfield & 0x01) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (Enabled)
                bitfield |= 0x01;

            writer.WriteByte(bitfield);
        }
    }
}
