using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsItemUndo : ArgsBase
    {
        private uint[] _upgradedFromItems = new uint[7];
        public uint ItemID { get; set; }
        public uint[] UpgradedFromItems => _upgradedFromItems;
        public float GoldGain { get; set; }

        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            ItemID = reader.ReadUInt32();
            for (int i = 0; i < UpgradedFromItems.Length; i++)
            {
                UpgradedFromItems[i] = reader.ReadUInt32();
            }
            GoldGain = reader.ReadFloat();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteUInt32(ItemID);
            for (int i = 0; i < UpgradedFromItems.Length; i++)
            {
                writer.WriteUInt32(UpgradedFromItems[i]);
            }
            writer.WriteFloat(GoldGain);
        }
    }
}
