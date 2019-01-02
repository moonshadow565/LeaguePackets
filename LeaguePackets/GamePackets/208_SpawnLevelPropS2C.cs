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
    public class SpawnLevelPropS2C : GamePacket // 0xD0
    {
        public override GamePacketID ID => GamePacketID.SpawnLevelPropS2C;
        public NetID NetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public int SkinID { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 FacingDirection { get; set; }
        public Vector3 PositionOffset { get; set; }
        public Vector3 Scale { get; set; }
        public TeamID Team { get; set; }
        public byte SkillLevel { get; set; }
        public byte Rank { get; set; }
        public byte Type { get; set; }
        public string Name { get; set; } = "";
        public string PropName { get; set; } = "";
        public SpawnLevelPropS2C(){}

        public SpawnLevelPropS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.SkinID = reader.ReadInt32();
            this.Position = reader.ReadVector3();
            this.FacingDirection = reader.ReadVector3();
            this.PositionOffset = reader.ReadVector3();
            this.Scale = reader.ReadVector3();
            this.Team = (TeamID)reader.ReadUInt16();
            this.Rank = reader.ReadByte();
            this.SkillLevel = reader.ReadByte();
            this.Type = (byte)reader.ReadUInt32();
            this.Name = reader.ReadFixedString(64);
            this.PropName = reader.ReadFixedStringLast(64);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteInt32(SkinID);
            writer.WriteVector3(Position);
            writer.WriteVector3(FacingDirection);
            writer.WriteVector3(PositionOffset);
            writer.WriteVector3(Scale);
            writer.WriteUInt16((ushort)Team);
            writer.WriteByte(Rank);
            writer.WriteByte(SkillLevel);
            writer.WriteUInt32((byte)Type);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedStringLast(PropName, 64);
        }
    }
}
