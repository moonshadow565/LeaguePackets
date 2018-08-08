using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.EventArgs
{
    public abstract class ArgsMinionKill : ArgsDie
    {
        public uint MinionSkinNameHash { get; set; }
        public int MinionSkinID { get; set; }
        public TeamID MinionMapSideTeamID { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            MinionSkinNameHash = reader.ReadUInt32();
            MinionSkinID = reader.ReadInt32();
            MinionMapSideTeamID = reader.ReadTeamID();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteUInt32(MinionSkinNameHash);
            writer.WriteInt32(MinionSkinID);
            writer.WriteTeamID(MinionMapSideTeamID);
        }
    }
}
