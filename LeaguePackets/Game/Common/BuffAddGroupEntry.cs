using System;


namespace LeaguePackets.Game.Common
{
    public class BuffAddGroupEntry
    {
        public uint OwnerNetID { get; set; }
        public uint CasterNetID { get; set; }
        public byte Slot { get; set; }
        public byte Count { get; set; }
        public bool IsHidden { get; set; }
    }

    public static class BuffAddGroupEntryExtension
    {
        public static BuffAddGroupEntry ReadBuffInGroupAdd(this ByteReader reader)
        {
            var data = new BuffAddGroupEntry();
            data.OwnerNetID = reader.ReadUInt32();
            data.CasterNetID = reader.ReadUInt32();
            data.Slot = reader.ReadByte();
            data.Count = reader.ReadByte();
            data.IsHidden = reader.ReadBool();
            return data;

        }

        public static void WriteBuffInGroupAdd(this ByteWriter writer, BuffAddGroupEntry data)
        {
            if(data == null)
            {
                data = new BuffAddGroupEntry();
            }
            writer.WriteUInt32(data.OwnerNetID);
            writer.WriteUInt32(data.CasterNetID);
            writer.WriteByte(data.Slot);
            writer.WriteByte(data.Count);
            writer.WriteBool(data.IsHidden);
        }
    }
}
