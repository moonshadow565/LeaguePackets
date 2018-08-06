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
        // TODO: change bitfield to variables
        public uint Bitfield { get; set; }
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
            info.Bitfield = reader.ReadUInt32();
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
            writer.WriteUInt32(info.Bitfield);
        }
    }
}
