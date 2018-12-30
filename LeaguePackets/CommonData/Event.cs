using System;
using System.IO;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public abstract class Event
    {
        public abstract EventID EventID { get; }
        public NetID Source { get; set; }
        public abstract void ReadArgs(PacketReader reader);
        public abstract void WriteArgs(PacketWriter writer);
    }

    public static partial class EventExtension
    {
        public static Event ReadEvent(this PacketReader reader, bool useSource = true)
        {
            var id = (EventID)reader.ReadByte();
            if (!Enum.IsDefined(typeof(EventID), id))
            {
                throw new IOException("Unknow event ID!");
            }
            var ev = _lookup[id](reader);
            if(useSource)
            {
                ev.Source = reader.ReadNetID();
            }
            ev.ReadArgs(reader);
            return ev;
        }

        public static void WriteEvent(this PacketWriter writer, Event ev, bool useSource = true)
        {
            writer.WriteByte((byte)ev.EventID);
            if(useSource)
            {
                writer.WriteNetID(ev.Source);
            }
            ev.WriteArgs(writer);
        }
    }
}
