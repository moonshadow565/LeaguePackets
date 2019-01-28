
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_SpawnTurret : GamePacket // 0x123
    {
        public override GamePacketID ID => GamePacketID.S2C_SpawnTurret;
        public uint NetID { get; set; }
        public uint OwnerNetID { get; set; }
        public byte NetNodeID { get; set; }
        public string Name { get; set; } = "";
        public string SkinName { get; set; } = "";
        public int SkinID { get; set; }
        public Vector3 Position { get; set; }
        public float ModelDisappearOnDeathTime { get; set; }
        public bool IsInvulnerable { get; set; }
        public bool IsTargetable { get; set; }
        public ushort TeamID { get; set; }

        public uint IsTargetableToTeamSpellFlags { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.OwnerNetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
            this.SkinID = reader.ReadInt32();
            this.Position = reader.ReadVector3();
            this.ModelDisappearOnDeathTime = reader.ReadFloat();

            byte bitfield = reader.ReadByte();
            this.IsInvulnerable = (bitfield & 0x01) != 0;
            this.IsTargetable = (bitfield & 0x02) != 0;

            this.TeamID = reader.ReadUInt16();
            this.IsTargetableToTeamSpellFlags = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteUInt32(OwnerNetID);
            writer.WriteByte(NetNodeID);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedString(SkinName, 64);
            writer.WriteInt32(SkinID);
            writer.WriteVector3(Position);
            writer.WriteFloat(ModelDisappearOnDeathTime);

            byte bitfield = 0;
            if (IsInvulnerable)
                bitfield |= 0x01;
            if (IsTargetable)
                bitfield |= 0x02;
            writer.WriteByte(bitfield);

            writer.WriteUInt16(TeamID);
            writer.WriteUInt32(IsTargetableToTeamSpellFlags);
        }
    }
}
