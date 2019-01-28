
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class WaypointList : GamePacket // 0xB9
    {
        public override GamePacketID ID => GamePacketID.WaypointList;
        public int SyncID { get; set; }
        public List<Vector2> Waypoints { get; set; } = new List<Vector2>();

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadInt32();
            while (reader.BytesLeft >= 8)
            {
                Vector2 waypoint = reader.ReadVector2();
                this.Waypoints.Add(waypoint);
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SyncID);
            foreach (var waypoint in Waypoints)
            {
                writer.WriteVector2(waypoint);
            }
        }
    }
}
