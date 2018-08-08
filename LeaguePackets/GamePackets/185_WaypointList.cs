using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class WaypointList : GamePacket // 0xB9
    {
        public override GamePacketID ID => GamePacketID.WaypointList;
        public int SyncID { get; set; }
        public List<Vector2> Waypoints { get; set; } = new List<Vector2>();
        public static WaypointList CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new WaypointList();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.SyncID = reader.ReadInt32();
            while ((reader.Stream.Length - reader.Stream.Position) >= 8)
            {
                Vector2 waypoint = reader.ReadVector2();
                result.Waypoints.Add(waypoint);
            }
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SyncID);
            foreach (var waypoint in Waypoints)
            {
                writer.WriteVector2(waypoint);
            }
        }
    }
}
