
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class SpawnMinionS2C : GamePacket // 0x7C
    {
        public override GamePacketID ID => GamePacketID.SpawnMinionS2C;
        public uint NetID { get; set; }
        public uint OwnerNetID { get; set; }
        public byte NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public int SkinID { get; set; }
        public uint CloneNetID { get; set; }
        public ushort TeamID { get; set; }
        public bool IgnoreCollision { get; set; }
        public bool IsWard { get; set; }
        public bool IsLaneMinion { get; set; }
        public bool IsBot { get; set; }
        public bool IsTargetable { get; set; }

        public uint IsTargetableToTeamSpellFlags { get; set; }
        public float VisibilitySize { get; set; }
        public string Name { get; set; } = "";
        public string SkinName { get; set; } = "";
        public ushort InitialLevel { get; set; }
        public uint OnlyVisibleToNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.OwnerNetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.SkinID = reader.ReadInt32();
            this.CloneNetID = reader.ReadUInt32();
            this.TeamID = reader.ReadUInt16();

            byte bitfield = reader.ReadByte();
            this.IgnoreCollision = (bitfield & 0x01) != 0;
            this.IsWard = (bitfield & 0x02) != 0;
            this.IsLaneMinion = (bitfield & 0x04) != 0;
            this.IsBot = (bitfield & 0x08) != 0;
            this.IsTargetable = (bitfield & 0x10) != 0;

            this.IsTargetableToTeamSpellFlags = reader.ReadUInt32();
            this.VisibilitySize = reader.ReadFloat();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
            this.InitialLevel = reader.ReadUInt16();
            this.OnlyVisibleToNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteUInt32(OwnerNetID);
            writer.WriteByte(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteInt32(SkinID);
            writer.WriteUInt32(CloneNetID);
            writer.WriteUInt16(TeamID);

            byte bitfield = 0;
            if (IgnoreCollision)
                bitfield |= 0x01;
            if (IsWard)
                bitfield |= 0x02;
            if (IsLaneMinion)
                bitfield |= 0x04;
            if (IsBot)
                bitfield |= 0x08;
            if (IsTargetable)
                bitfield |= 0x10;
            writer.WriteByte(bitfield);

            writer.WriteUInt32(IsTargetableToTeamSpellFlags);
            writer.WriteFloat(VisibilitySize);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedString(SkinName, 64);
            writer.WriteUInt16(InitialLevel);
            writer.WriteUInt32(OnlyVisibleToNetID);
        }
    }
}
