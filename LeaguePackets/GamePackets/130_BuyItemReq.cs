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
        public BuyItemReq(){}

        public BuyItemReq(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ItemID = reader.ReadItemID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemID(ItemID);
        }
    }
}
