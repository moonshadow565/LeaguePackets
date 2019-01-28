using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsChampionKillPre : ArgsBase
    {
        public byte Bitfield { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            Bitfield = reader.ReadByte();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteByte(Bitfield);
        }
    }
}
