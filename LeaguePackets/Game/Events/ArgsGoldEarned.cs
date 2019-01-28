using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsGoldEarned : ArgsBase
    {
        public float Ammount { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            Ammount = reader.ReadFloat();
            reader.ReadUInt64();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteFloat(Ammount);
            writer.WriteUInt64(0);
        }
    }
}
