using System;
using System.Collections.Generic;
using System.IO;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game.Common
{
    public enum ChangeSlotSpellDataType : byte
    {
        TargetingType = 0x1,
        SpellName = 0x2,
        Range = 0x3,
        MaxGrowthRange = 0x4,
        RangeDisplay = 0x5,
        IconIndex = 0x6,
        OffsetTarget = 0x7,
    }
}
