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
    public class S2C_SpawnTurret : GamePacket // 0x123
    {
        public override GamePacketID ID => GamePacketID.S2C_SpawnTurret;
        public NetID NetID { get; set; }
        public NetID OwnerNetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public string Name { get; set; } = "";
        public string SkinName { get; set; } = "";
        public int SkinID { get; set; }
        public Vector3 Position { get; set; }
        public float ModelDisappearOnDeathTime { get; set; }
        public TeamID TeamID { get; set; }
        public bool IsTargetable { get; set; }
        public bool IsInvulnerable { get; set; }

        public SpellFlags IsTargetableToTeam { get; set; }
        public static S2C_SpawnTurret CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_SpawnTurret();
            result.SenderNetID = senderNetID;
            result.NetID = reader.ReadNetID();
            result.OwnerNetID = reader.ReadNetID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.Name = reader.ReadFixedString(64);
            result.SkinName = reader.ReadFixedString(64);
            result.SkinID = reader.ReadInt32();
            result.Position = reader.ReadVector3();
            result.ModelDisappearOnDeathTime = reader.ReadFloat();
            ushort bitfield = reader.ReadUInt16();
            result.TeamID = (TeamID)(bitfield & 0x01FF);
            result.IsTargetable = (bitfield & 0x0200) != 0;
            result.IsInvulnerable = (bitfield & 0x400) != 0;

            result.IsTargetableToTeam = reader.ReadSpellFlags();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteNetID(OwnerNetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedString(SkinName, 64);
            writer.WriteInt32(SkinID);
            writer.WriteVector3(Position);
            writer.WriteFloat(ModelDisappearOnDeathTime);
            ushort bitfield = 0;
            bitfield |= (ushort)((ushort)TeamID & 0x01FF);
            if (IsTargetable)
                bitfield |= 0x0200;
            if (IsInvulnerable)
                bitfield |= 0x0400;
            writer.WriteUInt16(bitfield);

            writer.WriteSpellFlags(IsTargetableToTeam);
        }
    }
}
