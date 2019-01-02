using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{

    public class BuffInGroupUpdateCount
    {
        public NetID OwnerNetID { get; set; }
        public NetID CasterNetID { get; set; }
        public byte BuffSlot { get; set; }
        public byte Count { get; set; }
    }

    public static class BuffInGroupUpdateCountExtension
    {
        public static BuffInGroupUpdateCount ReadBuffInGroupUpdateCount(this PacketReader reader)
        {
            var data = new BuffInGroupUpdateCount();
            data.OwnerNetID = reader.ReadNetID();
            data.CasterNetID = reader.ReadNetID();
            data.BuffSlot = reader.ReadByte();
            data.Count = reader.ReadByte();
            return data;
        }

        public static void WriteBuffInGroupUpdateCount(this PacketWriter writer, BuffInGroupUpdateCount data)
        {
            if (data == null)
            {
                data = new BuffInGroupUpdateCount();
            }
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteNetID(data.CasterNetID);
            writer.WriteByte(data.BuffSlot);
            writer.WriteByte(data.Count);
        }
    }
}
