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
        public S2C_CreateNeutral(){}

        public S2C_CreateNeutral(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.Position = reader.ReadVector3();
            this.GroupPosition = reader.ReadVector3();
            this.FaceDirectionPosition = reader.ReadVector3();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
            this.UniqueName = reader.ReadFixedString(64);
            this.SpawnAnimationName = reader.ReadFixedString(64);
            this.TeamID = reader.ReadTeamID();
            this.DamageBonus = reader.ReadInt32();
            this.HealthBonus = reader.ReadInt32();
            this.RoamState = reader.ReadMinionRoamState();
            this.GroupNumber = reader.ReadInt32();
            this.BuffSide = reader.ReadInt32();
            this.RevealEvent = reader.ReadInt32();
            this.InitialLevel = reader.ReadInt32();
            this.SpawnDuration = reader.ReadFloat();
            this.SpawnTime = reader.ReadFloat();
            this.BehaviorTree = reader.ReadByte();
            this.AIscript = reader.ReadFixedString(32);
        
            this.ExtraBytes = reader.ReadLeft();
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
