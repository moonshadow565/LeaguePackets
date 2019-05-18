
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public enum CreateHeroDeath : byte
    {
        Alive = 0,
        Zombie = 1,
        Dead = 2
    }

    public class S2C_CreateHero : GamePacket // 0x4C
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateHero;
        public uint NetID { get; set; }
        public int ClientID { get; set; }
        public byte NetNodeID { get; set; }
        public byte SkillLevel { get; set; }
        public bool TeamIsOrder { get; set; }
        public bool IsBot { get; set; }
        public byte BotRank { get; set; }
        public byte SpawnPositionIndex { get; set; }
        public int SkinID { get; set; }
        public string Name { get; set; } = "";
        public string Skin { get; set; } = "";
        public float DeathDurationRemaining { get; set; }
        public float TimeSinceDeath { get; set; }

        public CreateHeroDeath CreateHeroDeath { get; set; }
        // FIXME: fix those unknowns
        public bool IsChangeHero { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.ClientID = reader.ReadInt32();
            this.NetNodeID = reader.ReadByte();
            this.SkillLevel = reader.ReadByte();
            this.TeamIsOrder = reader.ReadBool();
            this.IsBot = reader.ReadBool();
            this.BotRank = reader.ReadByte();
            this.SpawnPositionIndex = reader.ReadByte();
            this.SkinID = reader.ReadInt32();
            this.Name = reader.ReadFixedString(128);
            this.Skin = reader.ReadFixedString(40);
            this.DeathDurationRemaining = reader.ReadFloat();
            this.TimeSinceDeath = reader.ReadFloat();

            byte bitfield2 = reader.ReadByte();
            this.CreateHeroDeath = (CreateHeroDeath)(byte)(bitfield2 & 7);
            this.IsChangeHero = (bitfield2 & 0x08) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteInt32(ClientID);
            writer.WriteByte(NetNodeID);
            writer.WriteByte(SkillLevel);
            writer.WriteBool(TeamIsOrder);
            writer.WriteBool(IsBot);
            writer.WriteByte(BotRank);
            writer.WriteByte(SpawnPositionIndex);
            writer.WriteInt32(SkinID);
            writer.WriteFixedString(Name, 128);
            writer.WriteFixedString(Skin, 40);
            writer.WriteFloat(DeathDurationRemaining);
            writer.WriteFloat(TimeSinceDeath);

            byte bitfield2 = 0;
            bitfield2 |= (byte)((byte)(CreateHeroDeath) & 7);
            if (IsChangeHero)
            {
                bitfield2 |= 0x08;
            }
            writer.WriteByte(bitfield2);
        }
    }
}
