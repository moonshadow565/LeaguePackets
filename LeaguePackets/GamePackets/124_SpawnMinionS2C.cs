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
        public static SpawnMinionS2C CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new SpawnMinionS2C();
            result.SenderNetID = senderNetID;
            result.NetID = reader.ReadNetID();
            result.OwnerNetID = reader.ReadNetID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.Position = reader.ReadVector3();
            result.SkinID = reader.ReadInt32();
            result.CloneNetID = reader.ReadNetID();
            ushort bitfield = reader.ReadUInt16();
            result.TeamID = (TeamID)(bitfield & 0x1FF);
            result.IgnoreCollision = (bitfield & 0x0200) != 0;
            result.IsWard = (bitfield & 0x0400) != 0;
            result.IsLaneMinion = (bitfield & 0x0800) != 0;
            result.IsBot = (bitfield & 0x1000) != 0;
            result.IsTargetable = (bitfield & 0x2000) != 0;

            result.IsTargetableToTeam = reader.ReadSpellFlags();
            result.VisibilitySize = reader.ReadFloat();
            result.Name = reader.ReadFixedString(64);
            result.SkinName = reader.ReadFixedString(64);
            result.InitialLevel = reader.ReadUInt16();
            result.OnlyVisibleToNetID = reader.ReadNetID();
        
            return result;
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
