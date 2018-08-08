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
    public class BuyItemAns : GamePacket // 0x6F
    {
        public override GamePacketID ID => GamePacketID.BuyItemAns;
        public ItemDataPacket Item { get; set; } = new ItemDataPacket();
        // TODO: change bitfield to enum or variables
        public byte Bitfield { get; set; }
        public BuyItemAns(){}

        public BuyItemAns(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Item = reader.ReadItemPacket();
            this.Bitfield = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemPacket(Item);
            writer.WriteByte(Bitfield);
        }
    }
}
