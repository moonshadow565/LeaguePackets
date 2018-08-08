using System;
using LeaguePackets.Common;

namespace LeaguePackets
{
    public class KeyCheckPacket : BasePacket
    {
        public ClientID ClientID { get; set; }
        public PlayerID PlayerID { get; set; }
        public uint VersionNumber { get; set; }
        public ulong CheckSum { get; set; }

        public KeyCheckPacket() {}

        public KeyCheckPacket(PacketReader reader, ChannelID channelID) 
            : this(reader, channelID, reader.ReadByte())
        {}

        public KeyCheckPacket(PacketReader reader, ChannelID channelID, byte rawID)
        {
            ChannelID = channelID;
            reader.ReadPad(3);
            ClientID = reader.ReadClientID();
            PlayerID = reader.ReadPlayerID();
            VersionNumber = reader.ReadUInt32();
            CheckSum = reader.ReadUInt64();
            ExtraBytes = reader.ReadLeft();
        }

        public override void WriteHeader(PacketWriter writer)
        {
            writer.WriteByte(0);
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePad(3);
            writer.WriteClientID(ClientID);
            writer.WritePlayerID(PlayerID);
            writer.WriteUInt32(VersionNumber);
            writer.WriteUInt64(CheckSum);
        }
    }
}
