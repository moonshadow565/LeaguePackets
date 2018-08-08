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
    public class SpawnMinionS2C : GamePacket // 0x7C
    {
        public override GamePacketID ID => GamePacketID.SpawnMinionS2C;
        public NetID NetID { get; set; }
        public NetID OwnerNetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public int SkinID { get; set; }
        public NetID CloneNetID { get; set; }
        public TeamID TeamID { get; set; }
        public bool IgnoreCollision { get; set; }
        public bool IsWard { get; set; }
        public bool IsLaneMinion { get; set; }
        public bool IsBot { get; set; }
        public bool IsTargetable { get; set; }

        public SpellFlags IsTargetableToTeam { get; set; }
        public float VisibilitySize { get; set; }
        public string Name { get; set; } = "";
        public string SkinName { get; set; } = "";
        public ushort InitialLevel { get; set; }
        public NetID OnlyVisibleToNetID { get; set; }
        public SpawnMinionS2C(){}

        public SpawnMinionS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.OwnerNetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.Position = reader.ReadVector3();
            this.SkinID = reader.ReadInt32();
            this.CloneNetID = reader.ReadNetID();
            ushort bitfield = reader.ReadUInt16();
            this.TeamID = (TeamID)(bitfield & 0x1FF);
            this.IgnoreCollision = (bitfield & 0x0200) != 0;
            this.IsWard = (bitfield & 0x0400) != 0;
            this.IsLaneMinion = (bitfield & 0x0800) != 0;
            this.IsBot = (bitfield & 0x1000) != 0;
            this.IsTargetable = (bitfield & 0x2000) != 0;

            this.IsTargetableToTeam = reader.ReadSpellFlags();
            this.VisibilitySize = reader.ReadFloat();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
            this.InitialLevel = reader.ReadUInt16();
            this.OnlyVisibleToNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteNetID(OwnerNetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteInt32(SkinID);
            writer.WriteNetID(CloneNetID);
            ushort bitfield = 0;
            bitfield |= (ushort)((ushort)TeamID & 0x01FF);
            if (IgnoreCollision)
                bitfield |= 0x0200;
            if (IsWard)
                bitfield |= 0x0400;
            if (IsLaneMinion)
                bitfield |= 0x0800;
            if (IsBot)
                bitfield |= 0x1000;
            if (IsTargetable)
                bitfield |= 0x2000;
                    
            writer.WriteUInt16(bitfield);
            writer.WriteSpellFlags(IsTargetableToTeam);
            writer.WriteFloat(VisibilitySize);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedString(SkinName, 64);
            writer.WriteUInt16(InitialLevel);
            writer.WriteNetID(OnlyVisibleToNetID);
        }
    }
}
