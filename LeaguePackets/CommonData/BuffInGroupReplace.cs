using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class BuffInGroupReplace
    {
        public NetID OwnerNetID { get; set; }
        public NetID CasterNetID { get; set; }
        public byte Slot { get; set; }
    }

    public static class BuffInGroupReplaceExtension
    {
        public static BuffInGroupReplace ReadBuffInGroupReplace(this PacketReader reader)
        {
            var data = new BuffInGroupReplace();
            data.OwnerNetID = reader.ReadNetID();
            data.CasterNetID = reader.ReadNetID();
            data.Slot = reader.ReadByte();
            return data;

        }

        public static void WriteBuffInGroupReplace(this PacketWriter writer, BuffInGroupReplace data)
        {
            if (data == null)
            {
                data = new BuffInGroupReplace();
            }
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteNetID(data.CasterNetID);
            writer.WriteByte(data.Slot);
        }
    }
}
