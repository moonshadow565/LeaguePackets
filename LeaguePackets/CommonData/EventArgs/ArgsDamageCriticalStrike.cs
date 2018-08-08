using System;
namespace LeaguePackets.CommonData.EventArgs
{
    public abstract class ArgsDamageCriticalStrike : ArgsBase
    {
        public float Damage { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            Damage = reader.ReadFloat();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteFloat(Damage);
        }
    }
}
