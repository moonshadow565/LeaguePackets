
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class CHAR_SpawnPet : GamePacket // 0x37
    {
        public override GamePacketID ID => GamePacketID.CHAR_SpawnPet;
        public uint OwnerNetID { get; set; }
        public byte NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public int CastSpellLevelPlusOne { get; set; }
        public float Duration { get; set; }
        public uint TeamID { get; set; }
        public int DamageBonus { get; set; }
        public int HealthBonus { get; set; }
        public string Name { get; set; } = "";
        public string Skin { get; set; } = "";
        public int SkinID { get; set; }
        public string BuffName { get; set; }
        public uint CloneID { get; set; }
        public bool CloneInventory { get; set; }
        public bool ShowMinimapIconIfClone { get; set; }
        //FIXME: figure those out:
        public bool Unknown4 { get; set; }
        public bool DoFade { get; set; }
        string AIscript { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.OwnerNetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.CastSpellLevelPlusOne = reader.ReadInt32();
            this.Duration = reader.ReadFloat();
            this.TeamID = reader.ReadUInt32();
            this.DamageBonus = reader.ReadInt32();
            this.HealthBonus = reader.ReadInt32();
            this.Name = reader.ReadFixedString(128);
            this.Skin = reader.ReadFixedString(32);
            this.SkinID = reader.ReadInt32();
            this.BuffName = reader.ReadFixedString(64);
            this.CloneID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.CloneInventory = (bitfield & 1) != 0;
            this.ShowMinimapIconIfClone = (bitfield & 2) != 0;
            this.Unknown4 = (bitfield & 4) != 0;
            this.DoFade = (bitfield & 8) != 0;

            this.AIscript = reader.ReadFixedStringLast(32);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(OwnerNetID);
            writer.WriteByte(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteInt32(CastSpellLevelPlusOne);
            writer.WriteFloat(Duration);
            writer.WriteUInt32(TeamID);
            writer.WriteInt32(DamageBonus);
            writer.WriteInt32(HealthBonus);
            writer.WriteFixedString(Name, 128);
            writer.WriteFixedString(Skin, 32);
            writer.WriteInt32(SkinID);
            writer.WriteFixedString(BuffName, 64);
            writer.WriteUInt32(CloneID);
            byte bitfield = 0;
            if (CloneInventory)
                bitfield |= 1;
            if (ShowMinimapIconIfClone)
                bitfield |= 2;
            if (Unknown4)
                bitfield |= 4;
            if (DoFade)
                bitfield |= 8;

            writer.WriteByte(bitfield);
            writer.WriteFixedStringLast(AIscript, 32);            
        }
    }
}
