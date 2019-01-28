using System;


namespace LeaguePackets.Game.Common
{
    public class ItemData
    {
        public uint ItemID { get; set; }
        public byte Slot { get; set;}
        public byte ItemsInSlot { get; set; }
        public byte SpellCharges { get; set; }
    }

    public static class ItemDataExtension
    {
        public static ItemData ReadItemPacket(this ByteReader reader)
        {
            var item = new ItemData();
            item.ItemID = reader.ReadUInt32();
            item.Slot = reader.ReadByte();
            item.ItemsInSlot = reader.ReadByte();
            item.SpellCharges = reader.ReadByte();
            return item;
        }

        public static void WriteItemPacket(this ByteWriter writer, ItemData item)
        {
            if(item == null)
            {
                item = new ItemData();
            }
            writer.WriteUInt32(item.ItemID);
            writer.WriteByte(item.Slot);
            writer.WriteByte(item.ItemsInSlot);
            writer.WriteByte(item.SpellCharges);
        }
    }
}
