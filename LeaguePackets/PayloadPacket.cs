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

        public static PayloadPacket CreatePayloadPacket(PacketReader reader, ChannelID channelID)
        {
            byte rawID = reader.ReadByte();
            return CreatePayloadPacket(reader, channelID, rawID);
        }

        public static PayloadPacket CreatePayloadPacket(PacketReader reader, ChannelID channelID, byte rawID)
        {
            var id = (PayloadPacketID)rawID;
            PayloadPacket packet;
            if(!Enum.IsDefined(typeof(PayloadPacketID), id))
            {
                packet = UnknownPayloadPacket.CreateBody(reader, channelID, id);
            }
            else
            {
                packet = _lookup[id](reader, channelID);
            }
            packet.ExtraBytes = reader.ReadLeft();
            return packet;
        }
    }
}
