using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsSurrenderVotes : ArgsBase
    {
        public int ForVote { get; set; }
        public int AgainstVote { get; set; }
        public TeamID TeamID { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            ForVote = reader.ReadInt32();
            AgainstVote = reader.ReadInt32();
            TeamID = (TeamID)reader.ReadUInt16();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteInt32(ForVote);
            writer.WriteInt32(AgainstVote);
            writer.WriteUInt16((ushort)TeamID);
        }
    }
}
