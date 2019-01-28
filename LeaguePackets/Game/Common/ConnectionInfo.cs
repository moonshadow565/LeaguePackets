using System;


namespace LeaguePackets.Game.Common
{
    public class ConnectionInfo
    {
        public int ClientID { get; set; }
        public long PlayerID { get; set; }
        public float Percentage { get; set; }
        public float ETA { get; set; }
        public ushort Count { get; set; }
        public ushort Ping { get; set; }
        public bool Ready { get; set; }
    }

    public static class ConnectionInfoExtension
    {
        public static ConnectionInfo ReadConnectionInfo(this ByteReader reader)
        {
            var info = new ConnectionInfo();
            info.ClientID = reader.ReadInt32();
            info.PlayerID = reader.ReadInt64();
            info.Percentage = reader.ReadFloat();
            info.ETA = reader.ReadFloat();
            info.Count = reader.ReadUInt16();
            info.Ping = reader.ReadUInt16();

            byte bitfield = reader.ReadByte();
            info.Ready = (bitfield & 0x01) != 0;

            return info;
        }

        public static void WriteConnectionInfo(this ByteWriter writer, ConnectionInfo info)
        {
            if (info == null)
            {
                info = new ConnectionInfo();
            }
            writer.WriteInt32(info.ClientID);
            writer.WriteInt64(info.PlayerID);
            writer.WriteFloat(info.Percentage);
            writer.WriteFloat(info.ETA);
            writer.WriteUInt16(info.Count);
            writer.WriteUInt16(info.Ping);

            byte bitfield = 0;
            if (info.Ready)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
