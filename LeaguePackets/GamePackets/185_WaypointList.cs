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
        public WaypointList(){}

        public WaypointList(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SyncID = reader.ReadInt32();
            while ((reader.Stream.Length - reader.Stream.Position) >= 8)
            {
                Vector2 waypoint = reader.ReadVector2();
                this.Waypoints.Add(waypoint);
            }
            this.ExtraBytes = reader.ReadLeft();
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
