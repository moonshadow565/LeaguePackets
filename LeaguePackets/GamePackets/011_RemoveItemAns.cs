using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class RemoveItemAns : GamePacket // 0xB
    {
        public override GamePacketID ID => GamePacketID.RemoveItemAns;
        public byte Slot { get; set; }
        public bool NotifyInventoryChange { get; set; }
        public byte ItemsInSlot { get; set; }
        public RemoveItemAns(){}

        public RemoveItemAns(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.Slot = (byte)(bitfield & 0x7Fu);
            this.NotifyInventoryChange = (bitfield & 0x80) != 0;
            this.ItemsInSlot = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)((byte)Slot & 0x7Fu);
            if (NotifyInventoryChange)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);
            writer.WriteByte(ItemsInSlot);
        }
    }
}
