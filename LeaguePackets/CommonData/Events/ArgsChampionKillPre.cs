using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsChampionKillPre : ArgsBase
    {
        public byte Bitfield { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            Bitfield = reader.ReadByte();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteByte(Bitfield);
        }
    }
}
