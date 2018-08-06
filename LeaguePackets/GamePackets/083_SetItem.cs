using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class SetItem : GamePacket // 0x53
    {
        public override GamePacketID ID => GamePacketID.SetItem;
        public ItemDataPacket Item { get; set; } = new ItemDataPacket();
        public static SetItem CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new SetItem();
            result.SenderNetID = senderNetID;
            result.Item = reader.ReadItemPacket();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemPacket(Item);
        }
    }
}
