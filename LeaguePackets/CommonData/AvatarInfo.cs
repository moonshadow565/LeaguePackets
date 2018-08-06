using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class AvatarInfo
    {
        private uint[] _itemIDs = new uint[30];
        private uint[] _summonerSpellIDs = new uint[2];
        private Talent[] _talents = new Talent[80];
        public uint[] ItemIDs => _itemIDs;
        public uint[] SummonerIDs => _summonerSpellIDs;
        public Talent[] Talents => _talents;
        public byte Level { get; set; }
        public byte WardSkin { get; set; }
    }

    public static class AvatarInfoExtension
    {
        public static AvatarInfo ReadAvatarInfo(this PacketReader reader)
        {
            var info = new AvatarInfo();
            for (var i = 0; i < info.ItemIDs.Length; i++)
            {
                info.ItemIDs[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < info.SummonerIDs.Length; i++)
            {
                info.SummonerIDs[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < info.Talents.Length; i++)
            {
                info.Talents[i] = reader.ReadTalent();
            }
            info.Level = reader.ReadByte();
            info.WardSkin = reader.ReadByte();
            return info;
        }

        public static void WriteAvatarInfo(this PacketWriter writer, AvatarInfo info)
        {
            if(info == null)
            {
                info = new AvatarInfo();
            }
            for (var i = 0; i < info.ItemIDs.Length; i++)
            {
                writer.WriteUInt32(info.ItemIDs[i]);
            }
            for (var i = 0; i < info.SummonerIDs.Length; i++)
            {
                writer.WriteUInt32(info.SummonerIDs[i]);
            }
            for (var i = 0; i < info.Talents.Length; i++)
            {
                writer.WriteTalent(info.Talents[i]);
            }
            writer.WriteByte(info.Level);
            writer.WriteByte(info.WardSkin);
        }
    }
}
