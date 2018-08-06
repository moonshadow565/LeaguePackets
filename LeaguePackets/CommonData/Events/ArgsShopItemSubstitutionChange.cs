using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsShopItemSubstitutionChange : ArgsBase
    {
        public bool EnableSubstitution { get; set; }
        public uint OriginalItemId { get; set; }
        public uint SubstitutedItemId { get; set; }

        public override void ReadArgs(PacketReader reader)
        {
            EnableSubstitution = reader.ReadBool();
            OriginalItemId = reader.ReadUInt32();
            SubstitutedItemId = reader.ReadUInt32();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteBool(EnableSubstitution);
            writer.WriteUInt32(OriginalItemId);
            writer.WriteUInt32(SubstitutedItemId);
        }
    }
}
