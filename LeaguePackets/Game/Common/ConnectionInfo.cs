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

            ushort bitfield = reader.ReadUInt16();
            info.Ping = (ushort)(bitfield & 0x7FFF);
            info.Ready = (byte)(bitfield & 0x8000) != 0;

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

            ushort bitfield = 0;
            bitfield |= (ushort)(info.Ping);
            if (info.Ready)
                bitfield |= 0x8000;
            writer.WriteUInt16(bitfield);
        }
    }
}
