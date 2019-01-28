using System;


namespace LeaguePackets.Game.Common
{
    public class PlayerLoadInfo
    {
        public long PlayerID { get; set; } = -1;
        public ushort SummonorLevel { get; set; }
        public uint SummonorSpell1 { get; set; }
        public uint SummonorSpell2 { get; set; }
        //TODO: change bitfield to enum or variables
        public byte Bitfield { get; set; }
        public uint TeamId { get; set; }
        public string BotName { get; set; } = "";
        public string BotSkinName { get; set; } = "";
        public string EloRanking { get; set; } = "";
        public int BotSkinID { get; set; }
        public int BotDifficulty { get; set; }
        public int ProfileIconId { get; set; }
        public byte AllyBadgeID { get; set; }
        public byte EnemyBadgeID { get; set; }
    }

    public static class PlayerLoadInfoExtension
    {
        public static PlayerLoadInfo ReadPlayerInfo(this ByteReader reader)
        {
            var info = new PlayerLoadInfo();
            info.PlayerID = reader.ReadInt64();
            info.SummonorLevel = reader.ReadUInt16();
            info.SummonorSpell1 = reader.ReadUInt32();
            info.SummonorSpell2 = reader.ReadUInt32();
            info.Bitfield = reader.ReadByte();
            info.TeamId = reader.ReadUInt32();
            info.BotName = reader.ReadFixedString(64);
            info.BotSkinName = reader.ReadFixedString(64);
            info.EloRanking = reader.ReadFixedString(16);
            info.BotSkinID = reader.ReadInt32();
            info.BotDifficulty = reader.ReadInt32();
            info.ProfileIconId = reader.ReadInt32();
            info.AllyBadgeID = reader.ReadByte();
            info.EnemyBadgeID = reader.ReadByte();
            return info;
        }

        public static void WritePlayerInfo(this ByteWriter writer, PlayerLoadInfo info)
        {
            if (info == null)
            {
                info = new PlayerLoadInfo();
            }
            writer.WriteInt64(info.PlayerID);
            writer.WriteUInt16(info.SummonorLevel);
            writer.WriteUInt32(info.SummonorSpell1);
            writer.WriteUInt32(info.SummonorSpell2);
            writer.WriteByte(info.Bitfield);
            writer.WriteUInt32(info.TeamId);
            writer.WriteFixedString(info.BotName, 64);
            writer.WriteFixedString(info.BotSkinName, 64);
            writer.WriteFixedString(info.EloRanking, 16);
            writer.WriteInt32(info.BotSkinID);
            writer.WriteInt32(info.BotDifficulty);
            writer.WriteInt32(info.ProfileIconId);
            writer.WriteByte(info.AllyBadgeID);
            writer.WriteByte(info.EnemyBadgeID);
        }
    }
}
