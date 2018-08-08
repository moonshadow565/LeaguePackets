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
    public class S2C_CreateNeutral : GamePacket // 0x63
    {
        public NetID NetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 GroupPosition { get; set; }
        public Vector3 FaceDirectionPosition { get; set; }
        public string Name { get; set; } = "";
        public string SkinName { get; set; } = "";
        public string UniqueName { get; set; } = "";
        public string SpawnAnimationName { get; set; } = "";
        public TeamID TeamID { get; set; }
        public int DamageBonus { get; set; }
        public int HealthBonus { get; set; }
        public MinionRoamState RoamState { get; set; }
        public int GroupNumber { get; set; }
        public int BuffSide { get; set; }
        public int RevealEvent { get; set; }
        public int InitialLevel { get; set; }
        public float SpawnDuration { get; set; }
        public float SpawnTime { get; set; }
        public byte BehaviorTree { get; set; }
        public string AIscript { get; set; } = "";
        public override GamePacketID ID => GamePacketID.S2C_CreateNeutral;
        public static S2C_CreateNeutral CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_CreateNeutral();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.NetID = reader.ReadNetID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.Position = reader.ReadVector3();
            result.GroupPosition = reader.ReadVector3();
            result.FaceDirectionPosition = reader.ReadVector3();
            result.Name = reader.ReadFixedString(64);
            result.SkinName = reader.ReadFixedString(64);
            result.UniqueName = reader.ReadFixedString(64);
            result.SpawnAnimationName = reader.ReadFixedString(64);
            result.TeamID = reader.ReadTeamID();
            result.DamageBonus = reader.ReadInt32();
            result.HealthBonus = reader.ReadInt32();
            result.RoamState = reader.ReadMinionRoamState();
            result.GroupNumber = reader.ReadInt32();
            result.BuffSide = reader.ReadInt32();
            result.RevealEvent = reader.ReadInt32();
            result.InitialLevel = reader.ReadInt32();
            result.SpawnDuration = reader.ReadFloat();
            result.SpawnTime = reader.ReadFloat();
            result.BehaviorTree = reader.ReadByte();
            result.AIscript = reader.ReadFixedString(32);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteVector3(GroupPosition);
            writer.WriteVector3(FaceDirectionPosition);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedString(SkinName, 64);
            writer.WriteFixedString(UniqueName, 64);
            writer.WriteFixedString(SpawnAnimationName, 64);
            writer.WriteTeamID(TeamID);
            writer.WriteInt32(DamageBonus);
            writer.WriteInt32(HealthBonus);
            writer.WriteMinionRoamState(RoamState);
            writer.WriteInt32(GroupNumber);
            writer.WriteInt32(BuffSide);
            writer.WriteInt32(RevealEvent);
            writer.WriteInt32(InitialLevel);
            writer.WriteFloat(SpawnDuration);
            writer.WriteFloat(SpawnTime);
            writer.WriteByte(BehaviorTree);
            writer.WriteFixedString(AIscript, 32);
        }
    }
}
