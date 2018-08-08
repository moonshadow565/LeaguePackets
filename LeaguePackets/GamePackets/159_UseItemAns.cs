using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UseItemAns : GamePacket // 0x9F
    {
        public override GamePacketID ID => GamePacketID.UseItemAns;
        public byte Slot { get; set; }
        public byte ItemsInSlot { get; set; }
        public byte SpellCharges { get; set; }
        public UseItemAns(){}

        public UseItemAns(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Slot = reader.ReadByte();
            this.ItemsInSlot = reader.ReadByte();
            this.SpellCharges = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(ItemsInSlot);
            writer.WriteByte(SpellCharges);
        }
    }
}
