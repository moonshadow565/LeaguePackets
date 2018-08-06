using System;
using System.Numerics;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class FXCreateData
    {
        public NetID TargetNetID { get; set; }
        public NetID NetAssignedNetID { get; set; }
        public NetID CasterNetID { get; set; }
        public NetID BindNetID { get; set; }
        public NetID KeywordNetID { get; set; }
        public short PositionX { get; set; }
        public float PositionY { get; set; }
        public short PositionZ { get; set; }
        public short TargetPositionX { get; set; }
        public float TargetPositionY { get; set; }
        public short TargetPositionZ { get; set; }
        public short OwnerPositionX { get; set; }
        public float OwnerPositionY { get; set; }
        public short OwnerPositionZ { get; set; }
        public Vector3 OrientationVector { get; set; }
        public float TimeSpent { get; set; }
        public float ScriptScale { get; set; }
    }

    public static class FXCreateDataExtension
    {
        public static FXCreateData ReadFXCreateData(this PacketReader reader)
        {
            var data = new FXCreateData();
            data.TargetNetID = reader.ReadNetID();
            data.NetAssignedNetID = reader.ReadNetID();
            data.CasterNetID = reader.ReadNetID();
            data.BindNetID = reader.ReadNetID();
            data.KeywordNetID = reader.ReadNetID();
            data.PositionX = reader.ReadInt16();
            data.PositionY = reader.ReadFloat();
            data.PositionZ = reader.ReadInt16();
            data.TargetPositionX = reader.ReadInt16();
            data.TargetPositionY = reader.ReadFloat();
            data.TargetPositionZ = reader.ReadInt16();
            data.PositionX = reader.ReadInt16();
            data.OwnerPositionY = reader.ReadFloat();
            data.OwnerPositionZ = reader.ReadInt16();
            data.OrientationVector = reader.ReadVector3();
            data.TimeSpent = reader.ReadFloat();
            data.ScriptScale = reader.ReadFloat();
            return data;
        }

        public static void WriteFXCreateData(this PacketWriter writer, FXCreateData data)
        {
            writer.WriteNetID(data.TargetNetID);
            writer.WriteNetID(data.NetAssignedNetID);
            writer.WriteNetID(data.CasterNetID);
            writer.WriteNetID(data.BindNetID);
            writer.WriteNetID(data.KeywordNetID);
            writer.WriteInt16(data.PositionX);
            writer.WriteFloat(data.PositionY);
            writer.WriteInt16(data.PositionZ);
            writer.WriteInt16(data.TargetPositionX);
            writer.WriteFloat(data.TargetPositionY);
            writer.WriteInt16(data.TargetPositionZ);
            writer.WriteInt16(data.PositionX);
            writer.WriteFloat(data.OwnerPositionY);
            writer.WriteInt16(data.OwnerPositionZ);
            writer.WriteVector3(data.OrientationVector);
            writer.WriteFloat(data.TimeSpent);
            writer.WriteFloat(data.ScriptScale);
        }
    }
}
