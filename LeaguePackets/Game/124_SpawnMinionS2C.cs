
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

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.SkinID = reader.ReadInt32();
            this.CloneNetID = reader.ReadUInt32();

            ushort bitfield = reader.ReadUInt16();
            this.TeamID = (ushort)(bitfield & 0x1FF);
            this.IgnoreCollision = (bitfield & 0x0200) != 0;
            this.IsWard = (bitfield & 0x0400) != 0;
            this.IsLaneMinion = (bitfield & 0x0800) != 0;
            this.IsBot = (bitfield & 0x1000) != 0;
            this.IsTargetable = (bitfield & 0x2000) != 0;

            this.IsTargetableToTeamSpellFlags = reader.ReadUInt32();
            this.VisibilitySize = reader.ReadFloat();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
            this.InitialLevel = reader.ReadUInt16();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteByte(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteInt32(SkinID);
            writer.WriteUInt32(CloneNetID);

            ushort bitfield = 0;
            bitfield |= (ushort)(TeamID & 0x01FF);
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

            writer.WriteUInt32(IsTargetableToTeamSpellFlags);
            writer.WriteFloat(VisibilitySize);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedString(SkinName, 64);
            writer.WriteUInt16(InitialLevel);
        }
    }
}
