
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class UseItemAns : GamePacket // 0x9F
    {
        public override GamePacketID ID => GamePacketID.UseItemAns;
        public byte Slot { get; set; }
        public byte ItemsInSlot { get; set; }
        public byte SpellCharges { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Slot = reader.ReadByte();
            this.ItemsInSlot = reader.ReadByte();
            this.SpellCharges = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(ItemsInSlot);
            writer.WriteByte(SpellCharges);
        }
    }
}
