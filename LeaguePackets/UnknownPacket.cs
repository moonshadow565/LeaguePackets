using System;
namespace LeaguePackets
{
    public class UnknownPacket : BasePacket, IUnknownPacket
    {
        public byte RawID { get; set; }

        public UnknownPacket() {}

        public UnknownPacket(PacketReader reader, ChannelID channelID, byte rawID)
        {
            ChannelID = channelID;
            RawID = rawID;
            ExtraBytes = reader.ReadLeft();
        }

        public override void WriteHeader(PacketWriter writer)
        {
            writer.WriteByte(RawID);
        }

        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
