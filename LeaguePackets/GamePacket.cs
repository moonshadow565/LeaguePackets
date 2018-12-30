using LeaguePackets.Common;
using LeaguePackets.GamePackets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public abstract partial class GamePacket : BasePacket
    {
        public abstract GamePacketID ID { get; }
        public NetID SenderNetID { get; set; }
        public override void WriteHeader(PacketWriter writer)
        {
            if(ID > GamePacketID.Batched)
            {
                writer.WriteByte((byte)GamePacketID.ExtendedPacket);
                writer.WriteNetID(SenderNetID);
                writer.WriteUInt16((ushort)ID);
            }
            else
            {
                writer.WriteByte((byte)ID);
                writer.WriteNetID(SenderNetID);
            }
        }
    }

    public static partial class GamePacketExtension
    {
        public static GamePacket ReadGamePacket(this PacketReader reader, ChannelID channel)
        {
            byte rawID = reader.ReadByte();
            return reader.ReadGamePacket(channel, rawID);
        }

        public static GamePacket ReadGamePacket(this PacketReader reader, ChannelID channel, byte rawID)
        {
            var sender = reader.ReadNetID();
            return reader.ReadGamePacket(channel, rawID, sender);
        }

        public static GamePacket ReadGamePacket(this PacketReader reader, ChannelID channelID, byte rawID, NetID sender)
        {
            var id = (GamePacketID)rawID;
            if (id == GamePacketID.ExtendedPacket)
            {
                id = (GamePacketID)reader.ReadUInt16();
            }
            GamePacket packet;
            if (!Enum.IsDefined(typeof(GamePacketID), id)
                || id == GamePacketID.ExtendedPacket
                || id == GamePacketID.Batched)
            {
                packet = new UnknownGamePacket(reader, channelID, sender, id);
            }
            else
            {
                packet = _lookup[id](reader, channelID, sender);
            }
            // packet.ExtraBytes = reader.ReadLeft(); We do this in each packet individualy instead??
            return packet;
        }
    }
}