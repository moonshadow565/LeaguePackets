using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.PayloadPackets
{
    public class UnknownPayloadPacket : PayloadPacket, IUnknownPacket
    {
        private PayloadPacketID _id;
        public override PayloadPacketID ID => _id;
        public PayloadPacketID PayloadPacketIDRaw
        {
            get => _id;
            set => _id = value;
        }

        public UnknownPayloadPacket(){}

        public UnknownPayloadPacket(PacketReader reader, ChannelID channelID, PayloadPacketID id)
        {
            _id = id;
            ChannelID = channelID;
            ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
