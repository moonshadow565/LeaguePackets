using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsItemConsumedPurchased : ArgsBase
    {
        public ItemID ItemID { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            ItemID = reader.ReadItemID();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteItemID(ItemID);
        }
    }
}
