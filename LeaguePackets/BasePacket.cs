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
        public ChannelID ChannelID { get; set; }
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
    }

    public static class BasePacketExtension
    {
        public static BasePacket ReadPacket(this PacketReader reader, ChannelID channel)
        {
            byte rawID = reader.ReadByte();
            if (rawID == 0xFF)
            {
                return new BatchPacket(reader, channel);
            }
            switch (channel)
            {
                case ChannelID.Default:
                    return new KeyCheckPacket(reader, channel, rawID);
                case ChannelID.ClientToServer:
                case ChannelID.SynchClock:
                case ChannelID.Broadcast:
                case ChannelID.BroadcastUnreliable:
                    return reader.ReadGamePacket(channel, rawID);
                case ChannelID.Chat:
                    return new Chat(reader, channel);
                case ChannelID.QuickChat:
                    return new QuickChat(reader, channel);
                case ChannelID.LoadingScreen:
                    return reader.ReadPayloadPacket(channel, rawID);
                default:
                    return new UnknownPacket(reader, channel, rawID);
            }
        }

        public static void WritePacket(this PacketWriter writer, BasePacket packet)
        {
            packet.Write(writer);
        }
    }
}
