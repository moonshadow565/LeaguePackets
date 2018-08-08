using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.EventArgs
{
    public abstract class ArgsEqualizeVotes : ArgsBase
    {
        public int ForVote { get; set; }
        public int AgainstVote { get; set; }

        public float GoldGranted { get; set; }
        public int ExperienceGranted { get; set; }
        public int TowersGranted { get; set; }

        public TeamID TeamID { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            ForVote = reader.ReadInt32();
            AgainstVote = reader.ReadInt32();
            GoldGranted = reader.ReadFloat();
            ExperienceGranted = reader.ReadInt32();
            TowersGranted = reader.ReadInt32();
            TeamID = (TeamID)reader.ReadUInt16();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteInt32(ForVote);
            writer.WriteInt32(AgainstVote);
            writer.WriteFloat(GoldGranted);
            writer.WriteInt32(ExperienceGranted);
            writer.WriteInt32(TowersGranted);
            writer.WriteUInt16((ushort)TeamID);
        }
    }
}
