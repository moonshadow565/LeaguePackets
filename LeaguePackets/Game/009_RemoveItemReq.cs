
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class RemoveItemReq : GamePacket // 0x9
    {
        public override GamePacketID ID => GamePacketID.RemoveItemReq;
        public byte Slot { get; set; }
        public bool Sell { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.Slot = (byte)(bitfield & 0x7F);
            this.Sell = (bitfield & 0x80) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(this.Slot & 0x7F);
            if (Sell)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);
        }
    }
}
