using System;
namespace LeaguePackets.Common
{
    public enum PARType : byte
    {
        Mana = 0x0,
        Energy = 0x1,
        None = 0x2,
        Shield = 0x3,
        BattleFury = 0x4,
        DragonFury = 0x5,
        Rage = 0x6,
        Heat = 0x7,
        GnarFury = 0x8,
        Ferocity = 0x9,
        BloodWell = 0xA,
        Wind = 0xB,
        Other = 0xC,
    }
}
