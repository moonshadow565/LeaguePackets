
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class SetItem : GamePacket // 0x53
    {
        public override GamePacketID ID => GamePacketID.SetItem;
        public ItemData Item { get; set; } = new ItemData();

        protected override void ReadBody(ByteReader reader)
        {

            this.Item = reader.ReadItemPacket();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteItemPacket(Item);
        }
    }
}
