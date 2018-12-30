using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsItemUndo : ArgsBase
    {
        private ItemID[] _upgradedFromItems = new ItemID[7];
        public ItemID ItemID { get; set; }
        public ItemID[] UpgradedFromItems => _upgradedFromItems;
        public float GoldGain { get; set; }

        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            ItemID = reader.ReadItemID();
            for (int i = 0; i < UpgradedFromItems.Length; i++)
            {
                UpgradedFromItems[i] = reader.ReadItemID();
            }
            GoldGain = reader.ReadFloat();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteItemID(ItemID);
            for (int i = 0; i < UpgradedFromItems.Length; i++)
            {
                writer.WriteItemID(UpgradedFromItems[i]);
            }
            writer.WriteFloat(GoldGain);
        }
    }
}
