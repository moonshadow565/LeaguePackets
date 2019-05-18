
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class RemoveItemAns : GamePacket // 0xB
    {
        public override GamePacketID ID => GamePacketID.RemoveItemAns;
        public byte Slot { get; set; }
        public bool NotifyInventoryChange { get; set; }
        public byte ItemsInSlot { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.Slot = (byte)(bitfield & 0x7Fu);
            this.NotifyInventoryChange = (bitfield & 0x80) != 0;

            this.ItemsInSlot = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(Slot & 0x7Fu);
            if (NotifyInventoryChange)
                bitfield |= (byte)0x80u;

            writer.WriteByte(bitfield);
            writer.WriteByte(ItemsInSlot);
        }
    }
}
