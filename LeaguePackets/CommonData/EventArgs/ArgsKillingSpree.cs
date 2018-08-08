using System;
namespace LeaguePackets.CommonData.EventArgs
{
    public abstract class ArgsKillingSpree : ArgsBase
    {
        public int Ammount { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            Ammount = reader.ReadInt32();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteInt32(Ammount);
        }
    }
}
