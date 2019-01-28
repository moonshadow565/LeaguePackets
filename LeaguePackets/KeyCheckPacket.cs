using System;


namespace LeaguePackets
{
    public class KeyCheckPacket : BasePacket
    {
        public byte Action { get; set; }
        public int ClientID { get; set; }
        public long PlayerID { get; set; }
        public uint VersionNumber { get; set; }
        public ulong CheckSum { get; set; }

        public static KeyCheckPacket Create(byte[] data) 
        {
            var packet = new KeyCheckPacket();
            packet.Read(data);
            return packet;
        }

        protected override void ReadHeader(ByteReader reader)
        {
            this.Action = reader.ReadByte();
            reader.ReadPad(3);
        }
       
        protected override void ReadBody(ByteReader reader)
        {
            ClientID = reader.ReadInt32();
            PlayerID = reader.ReadInt64();
            VersionNumber = reader.ReadUInt32();
            CheckSum = reader.ReadUInt64();
        }

        protected override void WriteHeader(ByteWriter writer)
        {
            writer.WriteByte(this.Action);
            writer.WritePad(3);
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
            writer.WriteInt64(PlayerID);
            writer.WriteUInt32(VersionNumber);
            writer.WriteUInt64(CheckSum);
            writer.WritePad(4);
        }
    }
}
