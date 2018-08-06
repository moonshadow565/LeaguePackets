using System;
namespace LeaguePackets.Common
{
    public enum DamageSource : uint
    {
        Raw = 0x0,
        InternalRaw = 0x1,
        Periodic = 0x2,
        Proc = 0x3,
        Reactive = 0x4,
        OnDeath = 0x5,
        Spell = 0x6,
        Attack = 0x7,
        Default = 0x8,
        SpellAoe = 0x9,
        SpellPersist = 0xA,
        Pet = 0xB,
    }
}
