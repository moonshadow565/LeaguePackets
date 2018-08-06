using System;
namespace LeaguePackets.Common
{
    public enum DamageResultType : byte
    {
        Invulnerable = 0x0,
        InvulnerableNoMessage = 0x1,
        Dodge = 0x2,
        Critical = 0x3,
        Normal = 0x4,
        Miss = 0x5,
    }
}
