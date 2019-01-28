using System;


namespace LeaguePackets.Game.Common
{
    public class BuffReplaceGroupEntry
    {
        public uint OwnerNetID { get; set; }
        public uint CasterNetID { get; set; }
        public byte Slot { get; set; }
    }

    public static class BuffReplaceGroupEntryExtension
    {
        public static BuffReplaceGroupEntry ReadBuffInGroupReplace(this ByteReader reader)
        {
            var data = new BuffReplaceGroupEntry();
            data.OwnerNetID = reader.ReadUInt32();
            data.CasterNetID = reader.ReadUInt32();
            data.Slot = reader.ReadByte();
            return data;

        }

        public static void WriteBuffInGroupReplace(this ByteWriter writer, BuffReplaceGroupEntry data)
        {
            if (data == null)
            {
                data = new BuffReplaceGroupEntry();
            }
            writer.WriteUInt32(data.OwnerNetID);
            writer.WriteUInt32(data.CasterNetID);
            writer.WriteByte(data.Slot);
        }
    }
}
