
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class BuyItemAns : GamePacket // 0x6F
    {
        public override GamePacketID ID => GamePacketID.BuyItemAns;
        public ItemData Item { get; set; } = new ItemData();
        // TODO: change bitfield to enum or variables
        public byte Bitfield { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Item = reader.ReadItemPacket();
            this.Bitfield = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteItemPacket(Item);
            writer.WriteByte(Bitfield);
        }
    }
}
