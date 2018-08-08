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
        public S2C_SpawnTurret(){}

        public S2C_SpawnTurret(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.OwnerNetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
            this.SkinID = reader.ReadInt32();
            this.Position = reader.ReadVector3();
            this.ModelDisappearOnDeathTime = reader.ReadFloat();
            ushort bitfield = reader.ReadUInt16();
            this.TeamID = (TeamID)(bitfield & 0x01FF);
            this.IsTargetable = (bitfield & 0x0200) != 0;
            this.IsInvulnerable = (bitfield & 0x400) != 0;

            this.IsTargetableToTeam = reader.ReadSpellFlags();
        
            this.ExtraBytes = reader.ReadLeft();
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
