using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsAlert : ArgsBase
    {
        public override void ReadArgs(PacketReader reader)
        {
             reader.ReadPad(4);
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WritePad(4);
        }
    }
}
