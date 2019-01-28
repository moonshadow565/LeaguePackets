using System;
namespace LeaguePackets.Game.Common
{
    public class Talent
    {
        public uint Hash { get; set; }
        public byte Level { get; set; }
    }

    public static class TalentExtension
    {
        public static Talent ReadTalent(this ByteReader reader)
        {
            var talent = new Talent();
            talent.Hash = reader.ReadUInt32();
            talent.Level = reader.ReadByte();
            return talent;
        }
        public static void WriteTalent(this ByteWriter writer, Talent talent)
        {
            if (talent == null)
            {
                talent = new Talent();
            }
            writer.WriteUInt32(talent.Hash);
            writer.WriteByte(talent.Level);
        }
    }
}
