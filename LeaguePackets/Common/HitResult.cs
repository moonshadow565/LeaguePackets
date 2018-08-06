using System;
namespace LeaguePackets.Common
{
    public enum HitResult : byte
    {
        Normal = 0x0,
        Critical = 0x1,
        Dodge = 0x2,
        Miss = 0x3,
    }
}
