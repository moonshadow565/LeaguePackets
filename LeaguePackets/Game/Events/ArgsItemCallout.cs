using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsItemCallout : ArgsBase
    {
        public uint ItemID { get; set; }
        public uint ItemCount { get; set; }
        public uint TeamID { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            ItemID = reader.ReadUInt32();
            ItemCount = reader.ReadUInt32();
            reader.ReadPad(24);
            TeamID = reader.ReadUInt32();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteUInt32(ItemID);
            writer.WriteUInt32(ItemCount);
            writer.WritePad(24);
            writer.WriteUInt32(TeamID);
        }
    }
}
