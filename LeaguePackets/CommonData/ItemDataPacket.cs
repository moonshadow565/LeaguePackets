using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class ItemDataPacket
    {
        public ItemID ItemID { get; set; }
        public byte Slot { get; set;}
        public byte ItemsInSlot { get; set; }
        public byte SpellCharges { get; set; }
    }

    public static class ItemPacketExtension
    {
        public static ItemDataPacket ReadItemPacket(this PacketReader reader)
        {
            var item = new ItemDataPacket();
            item.ItemID = reader.ReadItemID();
            item.Slot = reader.ReadByte();
            item.ItemsInSlot = reader.ReadByte();
            item.SpellCharges = reader.ReadByte();
            return item;
        }

        public static void WriteItemPacket(this PacketWriter writer, ItemDataPacket item)
        {
            if(item == null)
            {
                item = new ItemDataPacket();
            }
            writer.WriteItemID(item.ItemID);
            writer.WriteByte(item.Slot);
            writer.WriteByte(item.ItemsInSlot);
            writer.WriteByte(item.SpellCharges);
        }
    }
}
