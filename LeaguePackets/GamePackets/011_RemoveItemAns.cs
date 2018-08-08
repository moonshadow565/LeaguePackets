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
        public static RemoveItemAns CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new RemoveItemAns();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.Slot = (byte)(bitfield & 0x7Fu);
            result.NotifyInventoryChange = (bitfield & 0x80) != 0;
            result.ItemsInSlot = reader.ReadByte();
        
            return result;
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
