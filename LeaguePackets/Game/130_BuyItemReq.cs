
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class BuyItemReq : GamePacket // 0x82
    {
        public override GamePacketID ID => GamePacketID.BuyItemReq;
        public uint ItemID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ItemID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(ItemID);
        }
    }
}
