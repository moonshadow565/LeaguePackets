using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsGoldSpent : ArgsBase
    {
        public float Ammount { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            Ammount = reader.ReadFloat();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteFloat(Ammount);
        }
    }
}
