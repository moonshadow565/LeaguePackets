using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ShopItemSubstitutionSet : GamePacket // 0x11C
    {
        public override GamePacketID ID => GamePacketID.S2C_ShopItemSubstitutionSet;
        public ItemID OriginalItemID { get; set; }
        public ItemID ReplacementItemID { get; set; }
        public S2C_ShopItemSubstitutionSet(){}

        public S2C_ShopItemSubstitutionSet(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.OriginalItemID = reader.ReadItemID();
            this.ReplacementItemID = reader.ReadItemID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemID(OriginalItemID);
            writer.WriteItemID(ReplacementItemID);
        }
    }
}
