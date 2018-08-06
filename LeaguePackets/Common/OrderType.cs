using System;
namespace LeaguePackets.Common
{
    public enum OrderType : byte
    {
        OrderNone = 0x0,
        Hold = 0x1,
        MoveTo = 0x2,
        AttackTo = 0x3,
        TempCastSpell = 0x4,
        PetHardAttack = 0x5,
        PetHardMove = 0x6,
        AttackMove = 0x7,
        Taunt = 0x8,
        PetHardReturn = 0x9,
        Stop = 0xA,
        PetHardStop = 0xB,
        Use = 0xC,
        AttackTerrainSustained = 0xD,
        AttackTerrainOnce = 0xE,
        CastSpell = 0xF,
    }
}
