using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsDamageCriticalStrike : ArgsBase
    {
        public float Damage { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            Damage = reader.ReadFloat();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteFloat(Damage);
        }
    }
}
