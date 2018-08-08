using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class WaypointListHeroWithSpeed : GamePacket // 0x83
    {
        public override GamePacketID ID => GamePacketID.WaypointListHeroWithSpeed;
        public int SyncID { get; set; }
        public SpeedParams WaypointSpeedParams { get; set; } = new SpeedParams();
        public List<Vector2> Waypoints { get; set; } = new List<Vector2>();

        public WaypointListHeroWithSpeed(){}

        public WaypointListHeroWithSpeed(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SyncID = reader.ReadInt32();
            this.WaypointSpeedParams = reader.ReadWaypointSpeedParams();
            while((reader.Stream.Length - reader.Stream.Position) >= 8)
            {
                Vector2 waypoint = reader.ReadVector2();
                this.Waypoints.Add(waypoint);
            }
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
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
