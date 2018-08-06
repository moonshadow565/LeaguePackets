using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class BuffInGroupRemove
    {
        public NetID OwnerNetID { get; set; }
        public byte Slot { get; set; }
        public float RunTimeRemove { get; set; }
    }

    public static class BuffInGroupRemoveExtension
    {
        public static BuffInGroupRemove ReadBuffInGroupRemove(this PacketReader reader)
        {
            var data = new BuffInGroupRemove();
            data.OwnerNetID = reader.ReadNetID();
            data.Slot = reader.ReadByte();
            data.RunTimeRemove = reader.ReadFloat();
            return data;
        }

        public static void WriteBuffInGroupRemove(this PacketWriter writer, BuffInGroupRemove data)
        {
            if(data == null)
            {
                data = new BuffInGroupRemove();   
            }
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteByte(data.Slot);
            writer.WriteFloat(data.RunTimeRemove);
        }
    }
}
