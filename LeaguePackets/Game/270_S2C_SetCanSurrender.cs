
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetCanSurrender : GamePacket // 0x10E
    {
        public override GamePacketID ID => GamePacketID.S2C_SetCanSurrender;
        public bool CanSurrender { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.CanSurrender = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (CanSurrender)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
