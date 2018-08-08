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
        //TODO: bitfield
        public ushort Bitfield { get; set; }
        public byte SkillLevel { get; set; }
        public byte Rank { get; set; }
        public byte Type { get; set; }
        public string Name { get; set; } = "";
        public string PropName { get; set; } = "";
        public static SpawnLevelPropS2C CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SpawnLevelPropS2C();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.NetID = reader.ReadNetID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.SkinID = reader.ReadInt32();
            result.Position = reader.ReadVector3();
            result.FacingDirection = reader.ReadVector3();
            result.PositionOffset = reader.ReadVector3();
            result.Scale = reader.ReadVector3();
            result.Bitfield = reader.ReadUInt16();
            result.Rank = reader.ReadByte();
            result.SkillLevel = reader.ReadByte();
            result.Type = reader.ReadByte();
            result.Name = reader.ReadFixedString(64);
            result.PropName = reader.ReadFixedString(64);
        
            return result;
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
            writer.WriteUInt16(Bitfield);
            writer.WriteByte(Rank);
            writer.WriteByte(SkillLevel);
            writer.WriteByte(Type);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedString(PropName, 64);
        }
    }
}
