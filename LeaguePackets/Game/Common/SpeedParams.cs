using System;
using System.Numerics;


namespace LeaguePackets.Game.Common
{
    public class SpeedParams
    {
        public float PathSpeedOverride { get; set; }
        public float ParabolicGravity { get; set; }
        public Vector2 ParabolicStartPoint { get; set; }
        public bool Facing { get; set; }
        public uint FollowNetID { get; set; }
        public float FollowDistance { get; set; }
        public float FollowBackDistance { get; set; }
        public float FollowTravelTime { get; set; }
    }

    public static class SpeedParamsExtension
    {
        public static SpeedParams ReadWaypointSpeedParams(this ByteReader reader)
        {
            var data = new SpeedParams();
            data.PathSpeedOverride = reader.ReadFloat();
            data.ParabolicGravity = reader.ReadFloat();
            data.ParabolicStartPoint = reader.ReadVector2();
            data.Facing = reader.ReadBool();
            data.FollowNetID = reader.ReadUInt32();
            data.FollowDistance = reader.ReadFloat();
            data.FollowBackDistance = reader.ReadFloat();
            data.FollowTravelTime = reader.ReadFloat();
            return data;
        }

        public static void WriteWaypointSpeedParams(this ByteWriter writer, SpeedParams data)
        {
            if(data == null)
            {
                data = new SpeedParams();
            }
            writer.WriteFloat(data.PathSpeedOverride);
            writer.WriteFloat(data.ParabolicGravity);
            writer.WriteVector2(data.ParabolicStartPoint);
            writer.WriteBool(data.Facing);
            writer.WriteUInt32(data.FollowNetID);
            writer.WriteFloat(data.FollowDistance);
            writer.WriteFloat(data.FollowBackDistance);
            writer.WriteFloat(data.FollowTravelTime);
        }
    }
}
