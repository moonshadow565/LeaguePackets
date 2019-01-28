
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
        public byte ItemsInSlot { get; set; }
        public bool NotifyInventoryChange { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Slot = reader.ReadByte();
            this.ItemsInSlot = reader.ReadByte();

            byte bitfield = reader.ReadByte();
            this.NotifyInventoryChange = (bitfield & 0x01) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(ItemsInSlot);

            byte bitfield = 0;
            if (NotifyInventoryChange)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
