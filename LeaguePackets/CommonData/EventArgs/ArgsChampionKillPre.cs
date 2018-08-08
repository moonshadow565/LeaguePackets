using System;
namespace LeaguePackets.CommonData.EventArgs
{
    public abstract class ArgsChampionKillPre : ArgsBase
    {
        public byte Bitfield { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            reader.ReadPad(4);
            Bitfield = reader.ReadByte();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WritePad(4);
            writer.WriteByte(Bitfield);
        }
    }
}
