
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PauseAnimation : GamePacket // 0x71
    {
        public override GamePacketID ID => GamePacketID.S2C_PauseAnimation;
        public bool Pause { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.Pause = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (Pause)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
