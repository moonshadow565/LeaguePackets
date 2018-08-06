using System;
namespace LeaguePackets.Common
{
    public enum QuestEvent : byte
    {
        Press = 0x0,
        Rrelease = 0x1,
        Rollover = 0x2,
        Rollout = 0x3,
    }
}
