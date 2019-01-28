
using LeaguePackets.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LeaguePackets
{
    using GamePacketDict = Dictionary<GamePacketID, Func<GamePacket>>;
    public abstract partial class GamePacket : BasePacket
    {
        public abstract GamePacketID ID { get; }
        public uint SenderNetID { get; set; }

        protected override void ReadHeader(ByteReader reader)
        {
            var id = (GamePacketID)reader.ReadByte();
            if (ID > GamePacketID.Batched)
            {
                this.SenderNetID = reader.ReadUInt32();
                reader.ReadUInt16();
            }
            else if(id == GamePacketID.Batched)
            { 
                reader.ReadByte();
            }
            else
            {
                this.SenderNetID = reader.ReadUInt32();
            }
        }

        protected override void WriteHeader(ByteWriter writer)
        {
            if(ID > GamePacketID.Batched)
            {
                writer.WriteByte((byte)GamePacketID.ExtendedPacket);
                writer.WriteUInt32(SenderNetID);
                writer.WriteUInt16((ushort)ID);
            }
            else if (ID == GamePacketID.Batched)
            {
                writer.WriteByte((byte)GamePacketID.ExtendedPacket);
            }
            else
            {
                writer.WriteByte((byte)ID);
                writer.WriteUInt32(SenderNetID);
            }
        }
    
        public static GamePacket Create(byte[] data)
        {
            if(data.Length < 5)
            {
                throw new IOException("GamePacket too short!");
            }
            var id = (GamePacketID)data[0];
            if (id == GamePacketID.ExtendedPacket)
            {
                if (data.Length < 7)
                {
                    throw new IOException("Extended GamePacket too short!");
                }
                id = (GamePacketID)((ushort)(data[5]) | (ushort)(data[6] << 8));
            }
            if (!Lookup.ContainsKey(id))
            {
                throw new IOException("Unknown game packet!");
            }
            var packet = Lookup[id]();
            packet.Read(data);
            return packet;
        }

        protected static GamePacketDict GenerateLookup()
        {
            var lookup = new GamePacketDict();
            foreach (Type type in Assembly.GetAssembly(typeof(GamePacket)).GetTypes())
            {
                if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(GamePacket)))
                {
                    continue;
                }
                var tmp = (GamePacket)Activator.CreateInstance(type);
                var id = tmp.ID;
                if (lookup.ContainsKey(id))
                {
                    throw new Exception("ID already in lookup map");
                }
                var lambda = Expression.Lambda<Func<GamePacket>>(
                    Expression.New(type),
                    Array.Empty<ParameterExpression>()
                ).Compile();
                lookup.Add(id, lambda);
            }
            return lookup;
        }
        protected static readonly GamePacketDict Lookup = GenerateLookup();
    }
}