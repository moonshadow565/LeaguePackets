using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsGoldEarned : ArgsBase
    {
        public float Ammount { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            Ammount = reader.ReadFloat();
            reader.ReadPad(8);
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteFloat(Ammount);
            writer.WritePad(8);
        }
    }
}
