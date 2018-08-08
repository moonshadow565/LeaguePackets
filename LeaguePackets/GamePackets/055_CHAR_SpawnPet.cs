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
        public static CHAR_SpawnPet CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new CHAR_SpawnPet();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.OwnerNetID = reader.ReadNetID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.Position = reader.ReadVector3();
            result.CastSpellLevelPlusOne = reader.ReadInt32();
            result.Duration = reader.ReadFloat();
            result.TeamID = reader.ReadTeamID();
            result.DamageBonus = reader.ReadInt32();
            result.HealthBonus = reader.ReadInt32();
            result.Name = reader.ReadFixedString(128);
            result.Skin = reader.ReadFixedString(32);
            result.SkinID = reader.ReadInt32();
            result.BuffName = reader.ReadFixedString(64);
            result.CloneID = reader.ReadNetID();
            byte bitfield = reader.ReadByte();
            result.CloneInventory = (bitfield & 1) != 0;
            result.ShowMinimapIconIfClone = (bitfield & 2) != 0;
            result.AIscript = reader.ReadFixedString(32);

            return result;
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
            writer.WriteFixedString(AIscript, 32);            
        }
    }
}
