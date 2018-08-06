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
        public static S2C_ShopItemSubstitutionClear CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_ShopItemSubstitutionClear();
            result.SenderNetID = senderNetID;
            result.OriginalItemID = reader.ReadItemID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemID(OriginalItemID);
        }
    }
}
