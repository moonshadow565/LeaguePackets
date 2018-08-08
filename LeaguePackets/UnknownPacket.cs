using System;
namespace LeaguePackets
{
    public class UnknownPacket : BasePacket, IUnknownPacket
    {
        public byte RawID { get; set; }

        public static UnknownPacket CreateUnknownPacket(PacketReader reader, ChannelID channelID, byte rawID)
        {
            var result = new UnknownPacket();
            result.ChannelID = channelID;
            result.RawID = rawID;
            return result;
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
