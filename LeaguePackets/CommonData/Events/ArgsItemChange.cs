using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsItemChange : ArgsBase
    {
        public ItemID ItemID { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            ItemID = reader.ReadItemID();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteItemID(ItemID);
        }
    }
}
