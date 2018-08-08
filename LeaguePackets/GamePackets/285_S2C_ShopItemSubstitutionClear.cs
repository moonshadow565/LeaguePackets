using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ShopItemSubstitutionClear : GamePacket // 0x11D
    {
        public override GamePacketID ID => GamePacketID.S2C_ShopItemSubstitutionClear;
        public ItemID OriginalItemID { get; set; }
        public S2C_ShopItemSubstitutionClear(){}

        public S2C_ShopItemSubstitutionClear(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.OriginalItemID = reader.ReadItemID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemID(OriginalItemID);
        }
    }
}
