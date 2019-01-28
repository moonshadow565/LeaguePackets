using System;


namespace LeaguePackets.Game.Common
{
    public class BuffRemoveGroupEntry
    {
        public uint OwnerNetID { get; set; }
        public byte Slot { get; set; }
        public float RunTimeRemove { get; set; }
    }

    public static class BuffRemoveGroupEntryExtension
    {
        public static BuffRemoveGroupEntry ReadBuffInGroupRemove(this ByteReader reader)
        {
            var data = new BuffRemoveGroupEntry();
            data.OwnerNetID = reader.ReadUInt32();
            data.Slot = reader.ReadByte();
            data.RunTimeRemove = reader.ReadFloat();
            return data;
        }

        public static void WriteBuffInGroupRemove(this ByteWriter writer, BuffRemoveGroupEntry data)
        {
            if(data == null)
            {
                data = new BuffRemoveGroupEntry();   
            }
            writer.WriteUInt32(data.OwnerNetID);
            writer.WriteByte(data.Slot);
            writer.WriteFloat(data.RunTimeRemove);
        }
    }
}
