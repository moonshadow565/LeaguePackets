using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsKillingSpree : ArgsBase
    {
        public int Ammount { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            Ammount = reader.ReadInt32();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteInt32(Ammount);
        }
    }
}
