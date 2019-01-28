
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class SpawnLevelPropS2C : GamePacket // 0xD0
    {
        public override GamePacketID ID => GamePacketID.SpawnLevelPropS2C;
        public uint NetID { get; set; }
        public byte NetNodeID { get; set; }
        public int SkinID { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 FacingDirection { get; set; }
        public Vector3 PositionOffset { get; set; }
        public Vector3 Scale { get; set; }
        public ushort TeamID { get; set; }
        public byte SkillLevel { get; set; }
        public byte Rank { get; set; }
        public byte Type { get; set; }
        public string Name { get; set; } = "";
        public string PropName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.SkinID = reader.ReadInt32();
            this.Position = reader.ReadVector3();
            this.FacingDirection = reader.ReadVector3();
            this.PositionOffset = reader.ReadVector3();
            this.Scale = reader.ReadVector3();
            this.TeamID = reader.ReadUInt16();
            this.Rank = reader.ReadByte();
            this.SkillLevel = reader.ReadByte();
            this.Type = (byte)reader.ReadUInt32();
            this.Name = reader.ReadFixedString(64);
            this.PropName = reader.ReadFixedStringLast(64);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteByte(NetNodeID);
            writer.WriteInt32(SkinID);
            writer.WriteVector3(Position);
            writer.WriteVector3(FacingDirection);
            writer.WriteVector3(PositionOffset);
            writer.WriteVector3(Scale);
            writer.WriteUInt16(TeamID);
            writer.WriteByte(Rank);
            writer.WriteByte(SkillLevel);
            writer.WriteUInt32((byte)Type);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedStringLast(PropName, 64);
        }
    }
}
