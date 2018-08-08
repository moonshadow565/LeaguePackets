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
    public class CHAR_SpawnPet : GamePacket // 0x37
    {
        public override GamePacketID ID => GamePacketID.CHAR_SpawnPet;
        public NetID OwnerNetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public int CastSpellLevelPlusOne { get; set; }
        public float Duration { get; set; }
        public TeamID TeamID { get; set; }
        public int DamageBonus { get; set; }
        public int HealthBonus { get; set; }
        public string Name { get; set; } = "";
        public string Skin { get; set; } = "";
        public int SkinID { get; set; }
        public string BuffName { get; set; }
        public NetID CloneID { get; set; }
        public bool CloneInventory { get; set; }
        public bool ShowMinimapIconIfClone { get; set; }
        string AIscript { get; set; }
        public CHAR_SpawnPet(){}

        public CHAR_SpawnPet(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.OwnerNetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.Position = reader.ReadVector3();
            this.CastSpellLevelPlusOne = reader.ReadInt32();
            this.Duration = reader.ReadFloat();
            this.TeamID = reader.ReadTeamID();
            this.DamageBonus = reader.ReadInt32();
            this.HealthBonus = reader.ReadInt32();
            this.Name = reader.ReadFixedString(128);
            this.Skin = reader.ReadFixedString(32);
            this.SkinID = reader.ReadInt32();
            this.BuffName = reader.ReadFixedString(64);
            this.CloneID = reader.ReadNetID();
            byte bitfield = reader.ReadByte();
            this.CloneInventory = (bitfield & 1) != 0;
            this.ShowMinimapIconIfClone = (bitfield & 2) != 0;
            this.AIscript = reader.ReadFixedStringLast(32);

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(OwnerNetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteInt32(CastSpellLevelPlusOne);
            writer.WriteFloat(Duration);
            writer.WriteTeamID(TeamID);
            writer.WriteInt32(DamageBonus);
            writer.WriteInt32(HealthBonus);
            writer.WriteFixedString(Name, 128);
            writer.WriteFixedString(Skin, 32);
            writer.WriteInt32(SkinID);
            writer.WriteFixedString(BuffName, 64);
            writer.WriteNetID(CloneID);
            byte bitfield = 0;
            if (CloneInventory)
                bitfield |= 1;
            if (ShowMinimapIconIfClone)
                bitfield |= 2;
            writer.WriteByte(bitfield);
            writer.WriteFixedStringLast(AIscript, 32);            
        }
    }
}
