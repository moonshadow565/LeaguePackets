using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsGoldSpent : ArgsBase
    {
        public float Ammount { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            Ammount = reader.ReadFloat();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteFloat(Ammount);
        }
    }
}
