using System;
using System.Collections.Generic;
using System.IO;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game.Common
{
    public enum ChangeSlotSpellDataType : byte
    {
        TargetingType = 0x0,
        SpellName = 0x1,
        Range = 0x2,
        MaxGrowthRange = 0x3,
        RangeDisplay = 0x4,
        IconIndex = 0x5,
        OffsetTarget = 0x6,
    }
}
