
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class WaypointListHeroWithSpeed : GamePacket // 0x83
    {
        public override GamePacketID ID => GamePacketID.WaypointListHeroWithSpeed;
        public int SyncID { get; set; }
        public SpeedParams WaypointSpeedParams { get; set; } = new SpeedParams();
        public List<Vector2> Waypoints { get; set; } = new List<Vector2>();

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadInt32();
            this.WaypointSpeedParams = reader.ReadWaypointSpeedParams();
            while(reader.BytesLeft >= 8)
            {
                Vector2 waypoint = reader.ReadVector2();
                this.Waypoints.Add(waypoint);
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SyncID);
            writer.WriteWaypointSpeedParams(WaypointSpeedParams);
            foreach(var waypoint in Waypoints)
            {
                writer.WriteVector2(waypoint);
            }
        }
    }
}
