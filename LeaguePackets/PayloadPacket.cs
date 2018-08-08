using LeaguePackets.PayloadPackets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public abstract partial class PayloadPacket : BasePacket
    {
        public abstract PayloadPacketID ID { get; }
        public override void WriteHeader(PacketWriter writer)
        {
            writer.WriteByte((byte)ID);
        }
    }

    public static partial class PayloadPacketExtension
    {
        public static PayloadPacket ReadPayloadPacket(this PacketReader reader, ChannelID channelID)
        {
            byte rawID = reader.ReadByte();
            return reader.ReadPayloadPacket(channelID, rawID);
        }

        public static PayloadPacket ReadPayloadPacket(this PacketReader reader, ChannelID channelID, byte rawID)
        {
            var id = (PayloadPacketID)rawID;
            PayloadPacket packet;
            if (!Enum.IsDefined(typeof(PayloadPacketID), id))
            {
                packet = new UnknownPayloadPacket(reader, channelID, id);
            }
            else
            {
                packet = _lookup[id](reader, channelID);
            }
            return packet;
        }
    }
}
