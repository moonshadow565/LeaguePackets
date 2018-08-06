using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsGoldSpent : ArgsBase
    {
        public float Ammount { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            Ammount = reader.ReadFloat();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteFloat(Ammount);
        }
    }
}
