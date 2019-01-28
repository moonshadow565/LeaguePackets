
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

            this.Slot = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.Sell = (bitfield & 0x01) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);
            byte bitfield = 0;
            if (Sell)
                bitfield |= (byte)0x01;
            writer.WriteByte(bitfield);
        }
    }
}
