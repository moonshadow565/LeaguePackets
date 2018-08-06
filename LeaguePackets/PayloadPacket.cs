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

        public static PayloadPacket Create(PacketReader reader)
        {
            byte rawID = reader.ReadByte();
            return Create(reader, rawID);
        }

        public static PayloadPacket Create(PacketReader reader, byte rawID)
        {
            var id = (PayloadPacketID)rawID;
            PayloadPacket packet;
            if(!Enum.IsDefined(typeof(PayloadPacketID), id))
            {
                packet = UnknownPayloadPacket.CreateBody(reader, id);
            }
            else
            {
                packet = _lookup[id](reader);
            }
            packet.ExtraBytes = reader.ReadLeft();
            return packet;
        }
    }
}
