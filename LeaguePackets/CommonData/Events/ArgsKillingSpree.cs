using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsKillingSpree : ArgsBase
    {
        public int Ammount { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            Ammount = reader.ReadInt32();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteInt32(Ammount);
        }
    }
}
