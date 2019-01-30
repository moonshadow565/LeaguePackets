using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace LeaguePackets.Game.Events
{
    using EventDict = Dictionary<EventID, Func<IEvent>>;

    public interface IEvent
    {
        EventID ID { get; }
        uint OtherNetID { get; set; }

        void ReadArgs(ByteReader reader);
        void WriteArgs(ByteWriter writer);
    }

    public interface IEventEmptyHistory : IEvent {}

    public class EventWorld
    {
        public uint Source { get; set; }
        public IEvent Event { get; set; } = new OnDelete();
    };

    public class EventHistoryEntry
    {
        public float Timestamp { get; set; }
        public ushort Count { get; set; }
        public uint Source { get; set; }
        public IEvent Event { get; set; } = new OnDelete();
    }

    public static class EventExtension
    {
        public static readonly EventDict Lookup = GenerateLookup();

        private static IEvent CreateEvent(byte rawID)
        {
            var id = (EventID)rawID;
            if (!Lookup.ContainsKey(id))
            {
                throw new IOException("Unknow event ID!");
            }
            return Lookup[id]();
        }

        public static IEvent ReadEvent(this ByteReader reader)
        {
            var id = reader.ReadByte();
            var ev = CreateEvent(id);
            ev.ReadArgs(reader);
            return ev;
        }

        public static void WriteEvent(this ByteWriter writer, IEvent ev)
        {
            writer.WriteByte((byte)ev.ID);
            ev.WriteArgs(writer);
        }

        public static EventWorld ReadEventWorld(this ByteReader reader)
        {
            var id = reader.ReadByte();
            var source = reader.ReadUInt32();
            var ev = CreateEvent(id);
            ev.ReadArgs(reader);
            return new EventWorld { Source = source, Event = ev };
        }

        public static void WriteEventWorld(this ByteWriter writer, EventWorld ev)
        {
            if(ev == null)
            {
                ev = new EventWorld();
            }
            writer.WriteByte((byte)ev.Event.ID);
            writer.WriteUInt32(ev.Source);
            ev.Event.WriteArgs(writer);
        }

        public static EventHistoryEntry ReadEventHistoryEntry(this ByteReader reader)
        {
            var timestamp = reader.ReadFloat();
            var count = reader.ReadUInt16();
            var id = reader.ReadByte();
            var source = reader.ReadUInt32();
            var ev = CreateEvent(id);
            if(ev is IEventEmptyHistory)
            {
                ev.OtherNetID = reader.ReadUInt32();
            }
            else
            {
                ev.ReadArgs(reader);
            }
            return new EventHistoryEntry
            {
                Timestamp = timestamp,
                Count = count,
                Source = source,
                Event = ev,
            };
        }

        public static void WriteEventHistoryEntry(this ByteWriter writer, EventHistoryEntry ev)
        {
            if (ev == null)
            {
                ev = new EventHistoryEntry();
            }
            writer.WriteFloat(ev.Timestamp);
            writer.WriteUInt16(ev.Count);
            writer.WriteByte((byte)ev.Event.ID);
            writer.WriteUInt32(ev.Source);
            if (ev.Event is IEventEmptyHistory)
            {
                writer.WriteUInt32(ev.Event.OtherNetID);
            }
            else
            {
                ev.Event.WriteArgs(writer);
            }
        }

        private static EventDict GenerateLookup()
        {
            var lookup = new EventDict();
            foreach (Type type in Assembly.GetAssembly(typeof(IEvent)).GetTypes())
            {
                if (!type.IsClass || type.IsAbstract || type.IsInterface || !typeof(IEvent).IsAssignableFrom(type))
                {
                    continue;
                }
                var tmp = (IEvent)Activator.CreateInstance(type);
                var id = tmp.ID;
                if (lookup.ContainsKey(id))
                {
                    throw new Exception("ID already in lookup map");
                }
                var lambda = Expression.Lambda<Func<IEvent>>(
                    Expression.New(type),
                    Array.Empty<ParameterExpression>()
                ).Compile();
                lookup.Add(id, lambda);
            }
            return lookup;
        }
    }
}
