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
        public SetItem(){}

        public SetItem(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Item = reader.ReadItemPacket();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemPacket(Item);
        }
    }
}
