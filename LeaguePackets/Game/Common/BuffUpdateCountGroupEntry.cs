using System;


namespace LeaguePackets.Game.Common
{
    public class BuffUpdateCountGroupEntry
    {
        public uint OwnerNetID { get; set; }
        public uint CasterNetID { get; set; }
        public byte BuffSlot { get; set; }
        public byte Count { get; set; }
    }

    public static class BuffUpdateCountGroupEntryExtension
    {
        public static BuffUpdateCountGroupEntry ReadBuffInGroupUpdateCount(this ByteReader reader)
        {
            var data = new BuffUpdateCountGroupEntry();
            data.OwnerNetID = reader.ReadUInt32();
            data.CasterNetID = reader.ReadUInt32();
            data.BuffSlot = reader.ReadByte();
            data.Count = reader.ReadByte();
            return data;
        }

        public static void WriteBuffInGroupUpdateCount(this ByteWriter writer, BuffUpdateCountGroupEntry data)
        {
            if (data == null)
            {
                data = new BuffUpdateCountGroupEntry();
            }
            writer.WriteUInt32(data.OwnerNetID);
            writer.WriteUInt32(data.CasterNetID);
            writer.WriteByte(data.BuffSlot);
            writer.WriteByte(data.Count);
        }
    }
}
