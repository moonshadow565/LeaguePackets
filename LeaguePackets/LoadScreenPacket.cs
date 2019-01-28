using LeaguePackets.LoadScreen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;

namespace LeaguePackets
{
    using LoadScreenDict = Dictionary<LoadScreenPacketID, Func<LoadScreenPacket>>;
    public abstract class LoadScreenPacket : BasePacket
    {
        public abstract LoadScreenPacketID ID { get; }

        protected override void ReadHeader(ByteReader reader)
        {
            reader.ReadPad(1);
        }

        protected override void WriteHeader(ByteWriter writer)
        {
            writer.WriteByte((byte)ID);
        }

        public static LoadScreenPacket Create(byte[] data)
        {
            if (data.Length < 1)
            {
                throw new IOException("LoadScreenPacket too short!");
            }
            var id = (LoadScreenPacketID)data[0];
            if (!Lookup.ContainsKey(id))
            {
                throw new IOException($"Unknown payload packet!");
            }
            var packet = Lookup[id]();
            packet.Read(data);
            return packet;
        }

        protected static LoadScreenDict GenerateLookup()
        {
            var lookup = new LoadScreenDict();
            foreach (Type type in Assembly.GetAssembly(typeof(LoadScreenPacket)).GetTypes())
            {
                if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(LoadScreenPacket)))
                {
                    continue;
                }
                var tmp = (LoadScreenPacket)Activator.CreateInstance(type);
                var id = tmp.ID;
                if (lookup.ContainsKey(id))
                {
                    throw new Exception("ID already in lookup map");
                }
                var lambda = Expression.Lambda<Func<LoadScreenPacket>>(
                    Expression.New(type),
                    Array.Empty<ParameterExpression>()
                ).Compile();
                lookup.Add(id, lambda);
            }
            return lookup;
        }
        protected static readonly LoadScreenDict Lookup = GenerateLookup();
    }
}
