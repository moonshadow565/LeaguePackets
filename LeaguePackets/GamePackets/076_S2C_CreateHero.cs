using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
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
        public NetID NetID { get; set; }
        public ClientID PlayerUID { get; set; }
        public NetNodeID NetNodeID { get; set; }
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
        public bool Unknown8 { get; set; } // something with scripts

        public static S2C_CreateHero CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_CreateHero();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.NetID = reader.ReadNetID();
            result.PlayerUID = reader.ReadClientID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.SkillLevel = reader.ReadByte();
            result.TeamIsOrder = reader.ReadBool();
            result.IsBot = reader.ReadBool();
            result.BotRank = reader.ReadByte();
            result.SpawnPositionIndex = reader.ReadByte();
            result.SkinID = reader.ReadInt32();
            result.Name = reader.ReadFixedString(128);
            result.Skin = reader.ReadFixedString(40);
            result.DeathDurationRemaining = reader.ReadFloat();
            result.TimeSinceDeath = reader.ReadFloat();
            byte bitfield = reader.ReadByte();
            result.CreateHeroDeath = (CreateHeroDeath)(bitfield & 7);
            result.Unknown8 = (bitfield & 8) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteClientID(PlayerUID);
            writer.WriteNetNodeID(NetNodeID);
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
            byte bitfield = 0;
            bitfield |= (byte)((byte)CreateHeroDeath & 7);
            if (Unknown8)
                bitfield |= 8;

            writer.WriteByte(bitfield);
        }
    }
}
