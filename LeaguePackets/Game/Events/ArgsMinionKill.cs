using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsMinionKill : ArgsDie
    {
        public uint MinionSkinNameHash { get; set; }
        public int MinionSkinID { get; set; }
        public uint MinionMapSideTeamID { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            MinionSkinNameHash = reader.ReadUInt32();
            MinionSkinID = reader.ReadInt32();
            MinionMapSideTeamID = reader.ReadUInt32();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteUInt32(MinionSkinNameHash);
            writer.WriteInt32(MinionSkinID);
            writer.WriteUInt32(MinionMapSideTeamID);
        }
    }
}
