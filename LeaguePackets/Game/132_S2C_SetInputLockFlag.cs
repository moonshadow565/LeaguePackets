
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetInputLockFlag : GamePacket // 0x84
    {
        public override GamePacketID ID => GamePacketID.S2C_SetInputLockFlag;
        public uint InputLockFlags { get; set; }
        public bool Value { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.InputLockFlags = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            this.Value = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(InputLockFlags);
            byte bitfield = 0;
            if (Value)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
