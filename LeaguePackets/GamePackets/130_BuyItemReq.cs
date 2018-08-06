using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class BuyItemReq : GamePacket // 0x82
    {
        public override GamePacketID ID => GamePacketID.BuyItemReq;
        public ItemID ItemID { get; set; }
        public static BuyItemReq CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new BuyItemReq();
            result.SenderNetID = senderNetID;
            result.ItemID = reader.ReadItemID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemID(ItemID);
        }
    }
}
