using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsDamageCriticalStrike : ArgsBase
    {
        public float Damage { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            Damage = reader.ReadFloat();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteFloat(Damage);
        }
    }
}
