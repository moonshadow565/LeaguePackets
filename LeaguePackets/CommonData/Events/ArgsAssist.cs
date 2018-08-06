using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsAssist : ArgsBase
    {
        public float AtTime { get; set; }
        public float PhysicalDamage { get; set; }
        public float MagicalDamage { get; set; }
        public float TrueDamage { get; set; }
        public float PercentageOfAssist { get; set; }
        public float OrginalGoldReward { get; set; }
        public NetID KillerNetID { get; set; }

        public override void ReadArgs(PacketReader reader)
        {
            AtTime = reader.ReadFloat();
            PhysicalDamage = reader.ReadFloat();
            MagicalDamage = reader.ReadFloat();
            TrueDamage = reader.ReadFloat();
            PercentageOfAssist = reader.ReadFloat();
            OrginalGoldReward = reader.ReadFloat();
            KillerNetID = reader.ReadNetID();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteFloat(AtTime);
            writer.WriteFloat(PhysicalDamage);
            writer.WriteFloat(MagicalDamage);
            writer.WriteFloat(TrueDamage);
            writer.WriteFloat(PercentageOfAssist);
            writer.WriteFloat(OrginalGoldReward);
            writer.WriteNetID(KillerNetID);
        }
    }
}
