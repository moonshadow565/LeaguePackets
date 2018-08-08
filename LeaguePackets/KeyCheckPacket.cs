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

        public static KeyCheckPacket Create(PacketReader reader)
        {
            byte rawID = reader.ReadByte();
            return CreateKeyCheckPacket(reader, rawID);
        }

        public static KeyCheckPacket CreateKeyCheckPacket(PacketReader reader, byte rawID)
        {
            var result = new KeyCheckPacket();
            reader.ReadPad(3);
            result.ClientID = reader.ReadClientID();
            result.PlayerID = reader.ReadPlayerID();
            result.VersionNumber = reader.ReadUInt32();
            result.CheckSum = reader.ReadUInt64();
            result.ExtraBytes = reader.ReadLeft();
            return result;
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
