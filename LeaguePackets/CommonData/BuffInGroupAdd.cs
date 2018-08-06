using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class BuffInGroupAdd
    {
        public NetID OwnerNetID { get; set; }
        public NetID CasterNetID { get; set; }
        public byte Slot { get; set; }
        public byte Count { get; set; }
        public bool IsHidden { get; set; }
    }

    public static class BuffInGroupAddExtension
    {
        public static BuffInGroupAdd ReadBuffInGroupAdd(this PacketReader reader)
        {
            var data = new BuffInGroupAdd();
            data.OwnerNetID = reader.ReadNetID();
            data.CasterNetID = reader.ReadNetID();
            data.Slot = reader.ReadByte();
            data.Count = reader.ReadByte();
            data.IsHidden = reader.ReadBool();
            return data;

        }

        public static void WriteBuffInGroupAdd(this PacketWriter writer, BuffInGroupAdd data)
        {
            if(data == null)
            {
                data = new BuffInGroupAdd();
            }
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteNetID(data.CasterNetID);
            writer.WriteByte(data.Slot);
            writer.WriteByte(data.Count);
            writer.WriteBool(data.IsHidden);
        }
    }
}
