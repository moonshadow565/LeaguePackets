using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.PayloadPackets;

namespace LeaguePackets
{
    public abstract class BasePacket
    {
        public byte[] ExtraBytes { get; set; } = new byte[0];
        public virtual void WriteBody(PacketWriter writer) { }
        public virtual void WriteHeader(PacketWriter writer) { }
        public void Write(PacketWriter writer)
        {
            WriteHeader(writer);
            WriteBody(writer);
            writer.WriteBytes(ExtraBytes);
        }

        public byte[] GetBytes()
        {
            byte[] buffer;
            using(var stream = new MemoryStream())
            {
                using(var writer = new PacketWriter(stream, true))
                {
                    Write(writer);
                }
                buffer = new byte[stream.Length];
                Buffer.BlockCopy(stream.GetBuffer(), 0, buffer, 0, buffer.Length);
            }
            return buffer;
        }

        public static BasePacket Create(PacketReader reader, ChannelID channel)
        {
            byte rawID = reader.ReadByte();
            return Create(reader, channel, rawID);
        }

        public static BasePacket Create(PacketReader reader, ChannelID channel, byte rawID)
        {
            if(rawID == 0xFF)
            {
                return BatchPacket.CreateBody(reader, channel);
            }
            switch (channel)
            {
                case ChannelID.Default:
                    return KeyCheckPacket.Create(reader, rawID);
                case ChannelID.ClientToServer:
                case ChannelID.SynchClock:
                case ChannelID.Broadcast:
                case ChannelID.BroadcastUnreliable:
                    return GamePacket.Create(reader, rawID);
                case ChannelID.Chat:
                    return Chat.CreateBody(reader);
                case ChannelID.QuickChat:
                    return QuickChat.CreateBody(reader);
                case ChannelID.LoadingScreen:
                    return PayloadPacket.Create(reader, rawID);
                default:
                    return null;
            }
        }
    }
}
