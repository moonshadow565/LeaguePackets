using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class ConnectionInfo
    {
        public ClientID ClientID { get; set; }
        public PlayerID PlayerID { get; set; }
        public float Percentage { get; set; }
        public float ETA { get; set; }
        public ushort Count { get; set; }
        public ushort Ping { get; set; }
        public bool Ready { get; set; }
    }

    public static class ConnectionInfoExtension
    {
        public static ConnectionInfo ReadConnectionInfo(this PacketReader reader)
        {
            var info = new ConnectionInfo();
            info.ClientID = reader.ReadClientID();
            info.PlayerID = reader.ReadPlayerID();
            info.Percentage = reader.ReadFloat();
            info.ETA = reader.ReadFloat();
            info.Count = reader.ReadUInt16();
            info.Ping = reader.ReadUInt16();

            byte bitfield = reader.ReadByte();
            info.Ready = (bitfield & 0x01) != 0;

            return info;
        }

        public static void WriteConnectionInfo(this PacketWriter writer, ConnectionInfo info)
        {
            if (info == null)
            {
                info = new ConnectionInfo();
            }
            writer.WriteClientID(info.ClientID);
            writer.WritePlayerID(info.PlayerID);
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
