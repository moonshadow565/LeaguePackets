using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;


namespace LeaguePackets.Game.Common
{
    public enum MovementDataType : byte
    {
        None = 0,
        WithSpeed = 1,
        Normal = 2,
        Stop = 3,
    }

    public abstract class MovementData
    {
        public abstract void Write(ByteWriter writer);
        public abstract MovementDataType Type { get; }
        public int SyncID { get; set; }
    }

    public static class MovementDataExtension
    {
        public static MovementData ReadMovementDataWithHeader(this ByteReader reader)
        {
            var type = reader.ReadMovementDataType();
            var movementSyncID = reader.ReadInt32();
            switch (type)
            {
                case MovementDataType.Stop:
                    return new MovementDataStop(reader, movementSyncID);
                case MovementDataType.Normal:
                    return new MovementDataNormal(reader, movementSyncID);
                case MovementDataType.WithSpeed:
                    return new MovementDataWithSpeed(reader, movementSyncID);
                default:
                    return new MovementDataNone(reader);
            }
        }

        public static void WriteMovementDataWithHeader(this ByteWriter writer, MovementData data)
        {
            writer.WriteMovementDataType(data.Type);
            writer.WriteInt32(data.SyncID);
            data.Write(writer);
        }
    }


    public class MovementDataNone : MovementData
    {
        public override MovementDataType Type => MovementDataType.None;

        public override void Write(ByteWriter writer)
        {
        }
        public MovementDataNone() {}
        public MovementDataNone(ByteReader reader)
        {
        }
    }

    public class MovementDataStop : MovementData
    {
        public override MovementDataType Type => MovementDataType.Stop;
        public Vector2 Position { get; set; }
        public Vector2 Forward { get; set; }
        
        public MovementDataStop() { }
        public MovementDataStop(ByteReader reader, int movementSyncID)
        {
            this.SyncID = movementSyncID;
            Position = reader.ReadVector2();
            Forward = reader.ReadVector2();
        }

        public override void Write(ByteWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteVector2(Forward);
        }
    }

    public class MovementDataNormal : MovementData
    {
        public override MovementDataType Type => MovementDataType.Normal;
        public uint TeleportNetID { get; set; }
        public bool HasTeleportID { get; set; }
        public byte TeleportID { get; set; }
        public List<CompressedWaypoint> Waypoints { get; set; }

        public MovementDataNormal() { }

        public MovementDataNormal(ByteReader reader, int movementSyncID)
        {
            this.SyncID = movementSyncID;
            byte bitfield = reader.ReadByte();
            byte size = (byte)(bitfield >> 1);
            HasTeleportID = (bitfield & 1) != 0;
            if (size > 0)
            {
                TeleportNetID = reader.ReadUInt32();
                if (HasTeleportID)
                {
                    TeleportID = reader.ReadByte();
                }
                Waypoints = reader.ReadCompressedWaypoints(size);
            }
        }

        public override void Write(ByteWriter writer)
        {
            int waypointsSize = Waypoints.Count;
            if(waypointsSize > 0x7F)
            {
                throw new Exception("Too many paths > 0x7F!");
            }
            byte bitfield = 0;
            if(Waypoints != null)
            {
                bitfield |= (byte)(waypointsSize << 1);
            }
            if (HasTeleportID)
            {
                bitfield |= 1;
            }
            writer.WriteByte(bitfield);
            if(Waypoints != null)
            {
                writer.WriteUInt32(TeleportNetID);
                if (HasTeleportID)
                {
                    writer.WriteByte(TeleportID);
                }
                writer.WriteCompressedWaypoints(Waypoints);
            }
        }
    }

    public class MovementDataWithSpeed : MovementDataNormal
    {
        public override MovementDataType Type => MovementDataType.WithSpeed;
        public SpeedParams SpeedParams { get; set; } = new SpeedParams();

        public MovementDataWithSpeed() { }
        public MovementDataWithSpeed(ByteReader reader, int movementSyncID)
        {
            this.SyncID = movementSyncID;
            byte bitfield = reader.ReadByte();
            byte size = (byte)(bitfield >> 1);
            HasTeleportID = (bitfield & 1) != 0;
            if (size > 0)
            {
                TeleportNetID = reader.ReadUInt32();
                if (HasTeleportID)
                {
                    TeleportID = reader.ReadByte();
                }
                SpeedParams = reader.ReadWaypointSpeedParams();
                Waypoints = reader.ReadCompressedWaypoints(size);
            }
        }

        public override void Write(ByteWriter writer)
        {
            int waypointsSize = Waypoints.Count;
            if (waypointsSize > 0x7F)
            {
                throw new Exception("Too many paths > 0x7F!");
            }
            byte bitfield = 0;
            if (Waypoints != null)
            {
                bitfield |= (byte)(waypointsSize  << 1);
            }
            if (HasTeleportID)
            {
                bitfield |= 1;
            }
            writer.WriteByte(bitfield);
            if (Waypoints != null)
            {
                writer.WriteUInt32(TeleportNetID);
                if (HasTeleportID)
                {
                    writer.WriteByte(TeleportID);
                }
                writer.WriteWaypointSpeedParams(SpeedParams);
                writer.WriteCompressedWaypoints(Waypoints);
            }
        }
    }

    public static class MovementExtension
    {
        public static MovementDataType ReadMovementDataType(this ByteReader reader)
        {
            return (MovementDataType)reader.ReadByte();
        }

        public static void WriteMovementDataType(this ByteWriter writer, MovementDataType type)
        {
            writer.WriteByte((byte)type);
        }
    }
}
