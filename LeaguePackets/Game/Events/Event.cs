using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace LeaguePackets.Game.Events
{
    using EventDict = Dictionary<EventID, Func<BaseEvent>>;
    public abstract class BaseEvent
    {
        public abstract EventID EventID { get; }
        public uint Source { get; set; }
        public abstract void ReadArgs(ByteReader reader);
        public abstract void WriteArgs(ByteWriter writer);

        private static EventDict GenerateLookup()
        {
            var lookup = new EventDict();
            foreach (Type type in Assembly.GetAssembly(typeof(BaseEvent)).GetTypes())
            {
                if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(BaseEvent)))
                {
                    continue;
                }
                var tmp = (BaseEvent)Activator.CreateInstance(type);
                var id = tmp.EventID;
                if (lookup.ContainsKey(id))
                {
                    throw new Exception("ID already in lookup map");
                }
                var lambda = Expression.Lambda<Func<BaseEvent>>(
                    Expression.New(type),
                    Array.Empty<ParameterExpression>()
                ).Compile();
                lookup.Add(id, lambda);
            }
            return lookup;
        }
        public static readonly EventDict Lookup = GenerateLookup();
    }

    public abstract class Event<TArgs> : BaseEvent where TArgs : ArgsBase, new()
    {
        public TArgs Args { get; set; } = new TArgs();
        public override void ReadArgs(ByteReader reader)
        {
            Args.ReadArgs(reader);
        }

        public override void WriteArgs(ByteWriter writer)
        {
            Args.WriteArgs(writer);
        }
    }

    public static partial class EventExtension
    {
        public static BaseEvent ReadEvent(this ByteReader reader, bool useSource = true)
        {
            var id = (EventID)reader.ReadByte();
            if (!BaseEvent.Lookup.ContainsKey(id))
            {
                throw new IOException("Unknow event ID!");
            }
            var ev = BaseEvent.Lookup[id]();
            if(useSource)
            {
                ev.Source = reader.ReadUInt32();
            }
            ev.ReadArgs(reader);
            return ev;
        }

        public static void WriteEvent(this ByteWriter writer, BaseEvent ev, bool useSource = true)
        {
            writer.WriteByte((byte)ev.EventID);
            if(useSource)
            {
                writer.WriteUInt32(ev.Source);
            }
            ev.WriteArgs(writer);
        }
    }
}
