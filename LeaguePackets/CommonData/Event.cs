using System;
using System.IO;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public abstract partial class Event
    {
        public abstract EventID EventID { get; }
        public abstract void ReadArgs(PacketReader reader);
        public abstract void WriteArgs(PacketWriter writer);

        public void Write(PacketWriter writer)
        {
            writer.WriteByte((byte)EventID);
            WriteArgs(writer);
        }
    }

    public static partial class EventExtension
    {
        public static Event ReadEvent(this PacketReader reader)
        {
            var id = (EventID)reader.ReadByte();
            if (!Enum.IsDefined(typeof(EventID), id))
            {
                throw new IOException("Unknow event ID!");
            }
            var ev = _lookup[id](reader);
            ev.ReadArgs(reader);
            return ev;
        }

        public static void WriteEvent(this PacketWriter writer, Event ev)
        {
            ev.Write(writer);
        }
    }
}
