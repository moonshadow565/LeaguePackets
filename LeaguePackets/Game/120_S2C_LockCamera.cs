
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_LockCamera : GamePacket // 0x78
    {
        public override GamePacketID ID => GamePacketID.S2C_LockCamera;
        public bool Lock { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.Lock = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (Lock)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
