using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsItemChange : ArgsBase
    {
        public uint ItemID { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            ItemID = reader.ReadUInt32();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteUInt32(ItemID);
        }
    }
}
