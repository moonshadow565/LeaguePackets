
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public enum CreateHeroDeath : uint
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
        public bool Unknown1 { get; set; } // something with scripts
        public bool Unknown2 { get; set; } // something with spawn

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.ClientID = reader.ReadInt32();
            this.NetNodeID = reader.ReadByte();
            this.SkillLevel = reader.ReadByte();

            byte bitfield1 = reader.ReadByte();
            this.TeamIsOrder = (bitfield1 & 0x01) != 0;
            this.IsBot = (bitfield1 & 0x02) != 0;

            this.BotRank = reader.ReadByte();
            this.SpawnPositionIndex = reader.ReadByte();
            this.SkinID = reader.ReadInt32();
            this.Name = reader.ReadFixedString(128);
            this.Skin = reader.ReadFixedString(40);
            this.DeathDurationRemaining = reader.ReadFloat();
            this.TimeSinceDeath = reader.ReadFloat();
            this.CreateHeroDeath = (CreateHeroDeath)reader.ReadUInt32();

            byte bitfield2 = reader.ReadByte();
            this.Unknown1 = (bitfield2 & 0x01) != 0;
            this.Unknown2 = (bitfield2 & 0x02) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteInt32(ClientID);
            writer.WriteByte(NetNodeID);
            writer.WriteByte(SkillLevel);

            byte bitfield1 = 0;
            if(TeamIsOrder)
            {
                bitfield1 |= 0x01;
            }
            if(IsBot)
            {
                bitfield1 |= 0x02;
            }
            writer.WriteByte(bitfield1);

            writer.WriteByte(BotRank);
            writer.WriteByte(SpawnPositionIndex);
            writer.WriteInt32(SkinID);
            writer.WriteFixedString(Name, 128);
            writer.WriteFixedString(Skin, 40);
            writer.WriteFloat(DeathDurationRemaining);
            writer.WriteFloat(TimeSinceDeath);
            writer.WriteUInt32((uint)CreateHeroDeath);

            byte bitfield2 = 0;
            if (Unknown1)
            {
                bitfield2 |= 0x01;
            }
            if (Unknown2)
            {
                bitfield2 |= 0x02;
            }
            writer.WriteByte(bitfield2);
        }
    }
}
