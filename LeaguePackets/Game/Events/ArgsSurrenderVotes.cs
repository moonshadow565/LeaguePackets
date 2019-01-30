using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsSurrenderVotes : ArgsBase
    {
        public int ForVote { get; set; }
        public int AgainstVote { get; set; }
        public ushort TeamID { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            ForVote = reader.ReadInt32();
            AgainstVote = reader.ReadInt32();
            TeamID = reader.ReadUInt16();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteInt32(ForVote);
            writer.WriteInt32(AgainstVote);
            writer.WriteUInt16(TeamID);
        }
    }
}
