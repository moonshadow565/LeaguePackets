using System;
using System.Collections.Generic;

namespace LeaguePackets.Game.Events
{
    public class OnDelete : ArgsBase, IEventEmptyHistory // 0
    {
        public EventID ID => EventID.OnDelete;
    }
    public class OnSpawn : ArgsDie, IEvent // 1
    {
        public EventID ID => EventID.OnSpawn;
    }
    public class OnDie : ArgsDie, IEvent // 2
    {
        public EventID ID => EventID.OnDie;
    }
    public class OnKill : ArgsBase, IEventEmptyHistory // 3
    {
        public EventID ID => EventID.OnKill;
    }
    public class OnChampionDie : ArgsDie, IEventEmptyHistory // 4
    {
        public EventID ID => EventID.OnChampionDie;
    }
    public class OnChampionKillPre : ArgsChampionKillPre, IEvent // 5
    {
        public EventID ID => EventID.OnChampionKillPre;
    }
    public class OnChampionKill : ArgsBase, IEventEmptyHistory // 6
    {
        public EventID ID => EventID.OnChampionKill;
    }
    public class OnChampionKillPost : ArgsBase, IEventEmptyHistory // 7
    {
        public EventID ID => EventID.OnChampionKillPost;
    }
    public class OnChampionSingleKill : ArgsBase, IEventEmptyHistory // 8
    {
        public EventID ID => EventID.OnChampionSingleKill;
    }
    public class OnChampionDoubleKill : ArgsBase, IEventEmptyHistory // 9
    {
        public EventID ID => EventID.OnChampionDoubleKill;
    }
    public class OnChampionTripleKill : ArgsBase, IEventEmptyHistory // 10
    {
        public EventID ID => EventID.OnChampionTripleKill;
    }
    public class OnChampionQuadraKill : ArgsBase, IEventEmptyHistory // 11
    {
        public EventID ID => EventID.OnChampionQuadraKill;
    }
    public class OnChampionPentaKill : ArgsBase, IEventEmptyHistory // 12
    {
        public EventID ID => EventID.OnChampionPentaKill;
    }
    public class OnChampionUnrealKill : ArgsBase, IEventEmptyHistory // 13
    {
        public EventID ID => EventID.OnChampionUnrealKill;
    }
    public class OnFirstBlood : ArgsBase, IEventEmptyHistory // 14
    {
        public EventID ID => EventID.OnFirstBlood;
    }
    public class OnDamageTaken : ArgsDamage, IEvent // 15
    {
        public EventID ID => EventID.OnDamageTaken;
    }
    public class OnDamageGiven : ArgsDamage, IEvent // 16
    {
        public EventID ID => EventID.OnDamageGiven;
    }
    public class OnSpellCast1 : ArgsBase, IEventEmptyHistory // 17
    {
        public EventID ID => EventID.OnSpellCast1;
    }
    public class OnSpellCast2 : ArgsBase, IEventEmptyHistory // 18
    {
        public EventID ID => EventID.OnSpellCast2;
    }
    public class OnSpellCast3 : ArgsBase, IEventEmptyHistory // 19
    {
        public EventID ID => EventID.OnSpellCast3;
    }
    public class OnSpellCast4 : ArgsBase, IEventEmptyHistory // 20
    {
        public EventID ID => EventID.OnSpellCast4;
    }
    public class OnSpellAvatarCast1 : ArgsBase, IEventEmptyHistory // 21
    {
        public EventID ID => EventID.OnSpellAvatarCast1;
    }
    public class OnSpellAvatarCast2 : ArgsBase, IEventEmptyHistory // 22
    {
        public EventID ID => EventID.OnSpellAvatarCast2;
    }
    public class OnGoldSpent : ArgsGoldSpent, IEvent // 23
    {
        public EventID ID => EventID.OnGoldSpent;
    }
    public class OnGoldEarned : ArgsGoldEarned, IEvent // 24
    {
        public EventID ID => EventID.OnGoldEarned;
    }
    public class OnItemConsumeablePurchased : ArgsItemConsumedPurchased, IEvent // 25
    {
        public EventID ID => EventID.OnItemConsumeablePurchased;
    }
    public class OnCriticalStrike : ArgsDamageCriticalStrike, IEvent // 26
    {
        public EventID ID => EventID.OnCriticalStrike;
    }
    public class OnAce : ArgsBase, IEventEmptyHistory // 27
    {
        public EventID ID => EventID.OnAce;
    }
    public class OnReincarnate : ArgsBase, IEventEmptyHistory // 28
    {
        public EventID ID => EventID.OnReincarnate;
    }
    public class OnChangeChampion : ArgsBase, IEventEmptyHistory // 29
    {
        public EventID ID => EventID.OnChangeChampion;
    }
    public class OnDampenerKill : ArgsBase, IEventEmptyHistory // 30
    {
        public EventID ID => EventID.OnDampenerKill;
    }
    public class OnDampenerDie : ArgsDie, IEventEmptyHistory // 31
    {
        public EventID ID => EventID.OnDampenerDie;
    }
    public class OnDampenerRespawnSoon : ArgsBase, IEventEmptyHistory // 32
    {
        public EventID ID => EventID.OnDampenerRespawnSoon;
    }
    public class OnDampenerRespawn : ArgsBase, IEventEmptyHistory // 33
    {
        public EventID ID => EventID.OnDampenerRespawn;
    }
    public class OnDampenerDamage : ArgsBase, IEventEmptyHistory // 34
    {
        public EventID ID => EventID.OnDampenerDamage;
    }
    public class OnTurretKill : ArgsBase, IEventEmptyHistory // 35
    {
        public EventID ID => EventID.OnTurretKill;
    }
    public class OnTurretDie : ArgsDie, IEvent // 36
    {
        public EventID ID => EventID.OnTurretDie;
    }
    public class OnTurretDamage : ArgsDie, IEvent // 37
    {
        public EventID ID => EventID.OnTurretDamage;
    }
    public class OnMinionKill : ArgsDie, IEvent // 38
    {
        public EventID ID => EventID.OnMinionKill;
    }
    public class OnMinionDenied : ArgsBase, IEventEmptyHistory // 39
    {
        public EventID ID => EventID.OnMinionDenied;
    }
    public class OnNeutralMinionKill : ArgsMinionKill, IEvent // 40
    {
        public EventID ID => EventID.OnNeutralMinionKill;
    }
    public class OnSuperMonsterKill : ArgsBase, IEventEmptyHistory // 41
    {
        public EventID ID => EventID.OnSuperMonsterKill;
    }
    public class OnAcquireRedBuffFromNeutral : ArgsBase, IEventEmptyHistory // 42
    {
        public EventID ID => EventID.OnAcquireRedBuffFromNeutral;
    }
    public class OnAcquireBlueBuffFromNeutral : ArgsBase, IEventEmptyHistory // 43
    {
        public EventID ID => EventID.OnAcquireBlueBuffFromNeutral;
    }
    public class OnHQKill : ArgsBase, IEventEmptyHistory // 44
    {
        public EventID ID => EventID.OnHQKill;
    }
    public class OnHQDie : ArgsBase, IEventEmptyHistory // 45
    {
        public EventID ID => EventID.OnHQDie;
    }
    public class OnHeal : ArgsHeal, IEvent // 46
    {
        public EventID ID => EventID.OnHeal;
    }
    public class OnCastHeal : ArgsHeal, IEvent // 47
    {
        public EventID ID => EventID.OnCastHeal;
    }
    public class OnBuff : ArgsBuff, IEvent // 48
    {
        public EventID ID => EventID.OnBuff;
    }
    public class OnCrowdControlDealt : ArgsCC, IEvent // 49
    {
        public EventID ID => EventID.OnCrowdControlDealt;
    }
    public class OnKillingSpree : ArgsKillingSpree, IEvent // 50
    {
        public EventID ID => EventID.OnKillingSpree;
    }
    public class OnKillingSpreeSet1 : ArgsBase, IEventEmptyHistory // 51
    {
        public EventID ID => EventID.OnKillingSpreeSet1;
    }
    public class OnKillingSpreeSet2 : ArgsBase, IEventEmptyHistory // 52
    {
        public EventID ID => EventID.OnKillingSpreeSet2;
    }
    public class OnKillingSpreeSet3 : ArgsBase, IEventEmptyHistory // 53
    {
        public EventID ID => EventID.OnKillingSpreeSet3;
    }
    public class OnKillingSpreeSet4 : ArgsBase, IEventEmptyHistory // 54
    {
        public EventID ID => EventID.OnKillingSpreeSet4;
    }
    public class OnKillingSpreeSet5 : ArgsBase, IEventEmptyHistory // 55
    {
        public EventID ID => EventID.OnKillingSpreeSet5;
    }
    public class OnKillingSpreeSet6 : ArgsBase, IEventEmptyHistory // 56
    {
        public EventID ID => EventID.OnKillingSpreeSet6;
    }
    public class OnKilledUnitOnKillingSpree : ArgsBase, IEventEmptyHistory // 57
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpree;
    }
    public class OnKilledUnitOnKillingSpreeSet1 : ArgsBase, IEventEmptyHistory // 58
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet1;
    }
    public class OnKilledUnitOnKillingSpreeSet2 : ArgsBase, IEventEmptyHistory // 59
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet2;
    }
    public class OnKilledUnitOnKillingSpreeSet3 : ArgsBase, IEventEmptyHistory // 60
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet3;
    }
    public class OnKilledUnitOnKillingSpreeSet4 : ArgsBase, IEventEmptyHistory // 61
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet4;
    }
    public class OnKilledUnitOnKillingSpreeSet5 : ArgsBase, IEventEmptyHistory // 62
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet5;
    }
    public class OnKilledUnitOnKillingSpreeSet6 : ArgsBase, IEventEmptyHistory // 63
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet6;
    }
    public class OnKilledUnitOnKillingSpreeDoubleKill : ArgsBase, IEventEmptyHistory // 64
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeDoubleKill;
    }
    public class OnKilledUnitOnKillingSpreeTripleKill : ArgsBase, IEventEmptyHistory // 65
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeTripleKill;
    }
    public class OnKilledUnitOnKillingSpreeQuadraKill : ArgsBase, IEventEmptyHistory // 66
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeQuadraKill;
    }
    public class OnKilledUnitOnKillingSpreePentaKill : ArgsBase, IEventEmptyHistory // 67
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreePentaKill;
    }
    public class OnKilledUnitOnKillingSpreeUnrealKill : ArgsBase, IEventEmptyHistory // 68
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeUnrealKill;
    }
    public class OnDeathAssist : ArgsAssist, IEvent // 69
    {
        public EventID ID => EventID.OnDeathAssist;
    }
    public class OnQuit : ArgsBase, IEventEmptyHistory // 70
    {
        public EventID ID => EventID.OnQuit;
    }
    public class OnLeave : ArgsBase, IEventEmptyHistory // 71
    {
        public EventID ID => EventID.OnLeave;
    }
    public class OnReconnect : ArgsBase, IEventEmptyHistory // 72
    {
        public EventID ID => EventID.OnReconnect;
    }
    public class OnGameStart : ArgsBase, IEventEmptyHistory // 73
    {
        public EventID ID => EventID.OnGameStart;
    }
    public class OnAssistingSpreeSet1 : ArgsBase, IEventEmptyHistory // 74
    {
        public EventID ID => EventID.OnAssistingSpreeSet1;
    }
    public class OnAssistingSpreeSet2 : ArgsBase, IEventEmptyHistory // 75
    {
        public EventID ID => EventID.OnAssistingSpreeSet2;
    }
    public class OnChampionTripleAssist : ArgsBase, IEventEmptyHistory // 76
    {
        public EventID ID => EventID.OnChampionTripleAssist;
    }
    public class OnChampionPentaAssist : ArgsBase, IEventEmptyHistory // 77
    {
        public EventID ID => EventID.OnChampionPentaAssist;
    }
    public class OnPing : ArgsBase, IEventEmptyHistory // 78
    {
        public EventID ID => EventID.OnPing;
    }
    public class OnPingPlayer : ArgsBase, IEventEmptyHistory // 79
    {
        public EventID ID => EventID.OnPingPlayer;
    }
    public class OnPingBuilding : ArgsBase, IEventEmptyHistory // 80
    {
        public EventID ID => EventID.OnPingBuilding;
    }
    public class OnPingOther : ArgsBase, IEventEmptyHistory // 81
    {
        public EventID ID => EventID.OnPingOther;
    }
    public class OnEndGame : ArgsBase, IEventEmptyHistory // 82
    {
        public EventID ID => EventID.OnEndGame;
    }
    public class OnSpellLevelup1 : ArgsBase, IEventEmptyHistory // 83
    {
        public EventID ID => EventID.OnSpellLevelup1;
    }
    public class OnSpellLevelup2 : ArgsBase, IEventEmptyHistory // 84
    {
        public EventID ID => EventID.OnSpellLevelup2;
    }
    public class OnSpellLevelup3 : ArgsBase, IEventEmptyHistory // 85
    {
        public EventID ID => EventID.OnSpellLevelup3;
    }
    public class OnSpellLevelup4 : ArgsBase, IEventEmptyHistory // 86
    {
        public EventID ID => EventID.OnSpellLevelup4;
    }
    public class OnSpellEvolve1 : ArgsBase, IEventEmptyHistory // 87
    {
        public EventID ID => EventID.OnSpellEvolve1;
    }
    public class OnSpellEvolve2 : ArgsBase, IEventEmptyHistory // 88
    {
        public EventID ID => EventID.OnSpellEvolve2;
    }
    public class OnSpellEvolve3 : ArgsBase, IEventEmptyHistory // 89
    {
        public EventID ID => EventID.OnSpellEvolve3;
    }
    public class OnSpellEvolve4 : ArgsBase, IEventEmptyHistory // 90
    {
        public EventID ID => EventID.OnSpellEvolve4;
    }
    public class OnItemPurchased : ArgsItemConsumedPurchased, IEvent // 91
    {
        public EventID ID => EventID.OnItemPurchased;
    }
    public class OnItemSold : ArgsItemSoldOrRemoved, IEvent // 92
    {
        public EventID ID => EventID.OnItemSold;
    }
    public class OnItemRemoved : ArgsItemSoldOrRemoved, IEvent // 93
    {
        public EventID ID => EventID.OnItemRemoved;
    }
    public class OnItemUndo : ArgsItemUndo, IEvent // 94
    {
        public EventID ID => EventID.OnItemUndo;
    }
    public class OnItemCallout : ArgsItemCallout, IEvent // 95
    {
        public EventID ID => EventID.OnItemCallout;
    }
    public class OnItemChange : ArgsItemChange, IEvent // 96
    {
        public EventID ID => EventID.OnItemChange;
    }
    public class OnUndoEnabledChange : ArgsUndoEnabledChange, IEvent // 97
    {
        public EventID ID => EventID.OnUndoEnabledChange;
    }
    public class OnShopItemSubstitutionChange : ArgsShopItemSubstitutionChange, IEvent // 98
    {
        public EventID ID => EventID.OnShopItemSubstitutionChange;
    }
    public class OnSurrenderVoteStart : ArgsBase, IEventEmptyHistory // 99
    {
        public EventID ID => EventID.OnSurrenderVoteStart;
    }
    public class OnSurrenderVote : ArgsBase, IEventEmptyHistory // 100
    {
        public EventID ID => EventID.OnSurrenderVote;
    }
    public class OnSurrenderVoteAlready : ArgsBase, IEventEmptyHistory // 101
    {
        public EventID ID => EventID.OnSurrenderVoteAlready;
    }
    public class OnSurrenderFailedVotes : ArgsBase, IEventEmptyHistory // 102
    {
        public EventID ID => EventID.OnSurrenderFailedVotes;
    }
    public class OnSurrenderTooEarly : ArgsBase, IEventEmptyHistory // 103
    {
        public EventID ID => EventID.OnSurrenderTooEarly;
    }
    public class OnSurrenderAgreed : ArgsBase, IEventEmptyHistory // 104
    {
        public EventID ID => EventID.OnSurrenderAgreed;
    }
    public class OnSurrenderSpam : ArgsBase, IEventEmptyHistory // 105
    {
        public EventID ID => EventID.OnSurrenderSpam;
    }
    public class OnSurrenderEarlyAllowed : ArgsBase, IEventEmptyHistory // 106
    {
        public EventID ID => EventID.OnSurrenderEarlyAllowed;
    }
    public class OnEqualizeVoteStart : ArgsBase, IEventEmptyHistory // 107
    {
        public EventID ID => EventID.OnEqualizeVoteStart;
    }
    public class OnEqualizeVote : ArgsBase, IEventEmptyHistory // 108
    {
        public EventID ID => EventID.OnEqualizeVote;
    }
    public class OnEqualizeVoteAlready : ArgsBase, IEventEmptyHistory // 109
    {
        public EventID ID => EventID.OnEqualizeVoteAlready;
    }
    public class OnEqualizeFailedVotes : ArgsBase, IEventEmptyHistory // 110
    {
        public EventID ID => EventID.OnEqualizeFailedVotes;
    }
    public class OnEqualizeTooEarly : ArgsBase, IEventEmptyHistory // 111
    {
        public EventID ID => EventID.OnEqualizeTooEarly;
    }
    public class OnEqualizeNotEnoughGold : ArgsBase, IEventEmptyHistory // 112
    {
        public EventID ID => EventID.OnEqualizeNotEnoughGold;
    }
    public class OnEqualizeNotEnoughLevels : ArgsBase, IEventEmptyHistory // 113
    {
        public EventID ID => EventID.OnEqualizeNotEnoughLevels;
    }
    public class OnEqualizeAgreed : ArgsBase, IEventEmptyHistory // 114
    {
        public EventID ID => EventID.OnEqualizeAgreed;
    }
    public class OnEqualizeSpam : ArgsBase, IEventEmptyHistory // 115
    {
        public EventID ID => EventID.OnEqualizeSpam;
    }
    public class OnPause : ArgsBase, IEventEmptyHistory // 116
    {
        public EventID ID => EventID.OnPause;
    }
    public class OnPauseResume : ArgsBase, IEventEmptyHistory // 117
    {
        public EventID ID => EventID.OnPauseResume;
    }
    public class OnMinionsSpawn : ArgsBase, IEventEmptyHistory // 118
    {
        public EventID ID => EventID.OnMinionsSpawn;
    }
    public class OnStartGameMessage1 : ArgsGlobalMessageGeneric, IEventEmptyHistory // 119
    {
        public EventID ID => EventID.OnStartGameMessage1;
    }
    public class OnStartGameMessage2 : ArgsGlobalMessageGeneric, IEventEmptyHistory // 120
    {
        public EventID ID => EventID.OnStartGameMessage2;
    }
    public class OnStartGameMessage3 : ArgsGlobalMessageGeneric, IEventEmptyHistory // 121
    {
        public EventID ID => EventID.OnStartGameMessage3;
    }
    public class OnStartGameMessage4 : ArgsGlobalMessageGeneric, IEventEmptyHistory // 122
    {
        public EventID ID => EventID.OnStartGameMessage4;
    }
    public class OnStartGameMessage5 : ArgsGlobalMessageGeneric, IEventEmptyHistory // 123
    {
        public EventID ID => EventID.OnStartGameMessage5;
    }
    public class OnAlert : ArgsAlert, IEventEmptyHistory // 124
    {
        public EventID ID => EventID.OnAlert;
    }
    public class OnScoreboardOpen : ArgsBase, IEventEmptyHistory // 125
    {
        public EventID ID => EventID.OnScoreboardOpen;
    }
    public class OnAudioEventFinished : ArgsBase, IEventEmptyHistory // 126
    {
        public EventID ID => EventID.OnAudioEventFinished;
    }
    public class OnNexusCrystalStart : ArgsBase, IEventEmptyHistory // 127
    {
        public EventID ID => EventID.OnNexusCrystalStart;
    }
    public class OnCapturePointNeutralized_A : ArgsBase, IEventEmptyHistory // 128
    {
        public EventID ID => EventID.OnCapturePointNeutralized_A;
    }
    public class OnCapturePointNeutralized_B : ArgsBase, IEventEmptyHistory // 129
    {
        public EventID ID => EventID.OnCapturePointNeutralized_B;
    }
    public class OnCapturePointNeutralized_C : ArgsBase, IEventEmptyHistory // 130
    {
        public EventID ID => EventID.OnCapturePointNeutralized_C;
    }
    public class OnCapturePointNeutralized_D : ArgsBase, IEventEmptyHistory // 131
    {
        public EventID ID => EventID.OnCapturePointNeutralized_D;
    }
    public class OnCapturePointNeutralized_E : ArgsBase, IEventEmptyHistory // 132
    {
        public EventID ID => EventID.OnCapturePointNeutralized_E;
    }
    public class OnCapturePointCaptured_A : ArgsBase, IEventEmptyHistory // 133
    {
        public EventID ID => EventID.OnCapturePointCaptured_A;
    }
    public class OnCapturePointCaptured_B : ArgsBase, IEventEmptyHistory // 134
    {
        public EventID ID => EventID.OnCapturePointCaptured_B;
    }
    public class OnCapturePointCaptured_C : ArgsBase, IEventEmptyHistory // 135
    {
        public EventID ID => EventID.OnCapturePointCaptured_C;
    }
    public class OnCapturePointCaptured_D : ArgsBase, IEventEmptyHistory // 136
    {
        public EventID ID => EventID.OnCapturePointCaptured_D;
    }
    public class OnCapturePointCaptured_E : ArgsBase, IEventEmptyHistory // 137
    {
        public EventID ID => EventID.OnCapturePointCaptured_E;
    }
    public class OnCapturePointFiveCap : ArgsBase, IEventEmptyHistory // 138
    {
        public EventID ID => EventID.OnCapturePointFiveCap;
    }
    public class OnVictoryPointThreshold1 : ArgsBase, IEventEmptyHistory // 139
    {
        public EventID ID => EventID.OnVictoryPointThreshold1;
    }
    public class OnVictoryPointThreshold2 : ArgsBase, IEventEmptyHistory // 140
    {
        public EventID ID => EventID.OnVictoryPointThreshold2;
    }
    public class OnVictoryPointThreshold3 : ArgsBase, IEventEmptyHistory // 141
    {
        public EventID ID => EventID.OnVictoryPointThreshold3;
    }
    public class OnVictoryPointThreshold4 : ArgsBase, IEventEmptyHistory // 142
    {
        public EventID ID => EventID.OnVictoryPointThreshold4;
    }
    public class OnMinionKillVictoryThreshold1 : ArgsBase, IEventEmptyHistory // 143
    {
        public EventID ID => EventID.OnMinionKillVictoryThreshold1;
    }
    public class OnMinionKillVictoryThreshold2 : ArgsBase, IEventEmptyHistory // 144
    {
        public EventID ID => EventID.OnMinionKillVictoryThreshold2;
    }
    public class OnTurretKillVictoryThreshold1 : ArgsBase, IEventEmptyHistory // 145
    {
        public EventID ID => EventID.OnTurretKillVictoryThreshold1;
    }
    public class OnTurretKillVictoryThreshold2 : ArgsBase, IEventEmptyHistory // 146
    {
        public EventID ID => EventID.OnTurretKillVictoryThreshold2;
    }
    public class OnReplayFastForwardStart : ArgsBase, IEventEmptyHistory // 147
    {
        public EventID ID => EventID.OnReplayFastForwardStart;
    }
    public class OnReplayFastForwardEnd : ArgsBase, IEventEmptyHistory // 148
    {
        public EventID ID => EventID.OnReplayFastForwardEnd;
    }
    public class OnReplayOnKeyframeFinished : ArgsBase, IEventEmptyHistory // 149
    {
        public EventID ID => EventID.OnReplayOnKeyframeFinished;
    }
    public class OnReplayDestroyAllObjects : ArgsBase, IEventEmptyHistory // 150
    {
        public EventID ID => EventID.OnReplayDestroyAllObjects;
    }
    public class OnKillDragon : ArgsMinionKill, IEvent // 151
    {
        public EventID ID => EventID.OnKillDragon;
    }
    public class OnKillDragon_Spectator : ArgsMinionKill, IEvent // 152
    {
        public EventID ID => EventID.OnKillDragon_Spectator;
    }
    public class OnKillDragonSteal : ArgsMinionKill, IEvent // 153
    {
        public EventID ID => EventID.OnKillDragonSteal;
    }
    public class OnKillWorm : ArgsMinionKill, IEvent // 154
    {
        public EventID ID => EventID.OnKillWorm;
    }
    public class OnKillWorm_Spectator : ArgsMinionKill, IEvent // 155
    {
        public EventID ID => EventID.OnKillWorm_Spectator;
    }
    public class OnKillWormSteal : ArgsMinionKill, IEvent // 156
    {
        public EventID ID => EventID.OnKillWormSteal;
    }
    public class OnKillSpiderBoss : ArgsMinionKill, IEvent // 157
    {
        public EventID ID => EventID.OnKillSpiderBoss;
    }
    public class OnKillSpiderBoss_Spectator : ArgsMinionKill, IEvent // 158
    {
        public EventID ID => EventID.OnKillSpiderBoss_Spectator;
    }
    public class OnCaptureAltar : ArgsCapturePoint, IEvent // 159
    {
        public EventID ID => EventID.OnCaptureAltar;
    }
    public class OnCaptureAltar_Spectator : ArgsCapturePoint, IEvent // 160
    {
        public EventID ID => EventID.OnCaptureAltar_Spectator;
    }
    public class OnPlaceWard : ArgsBase, IEventEmptyHistory // 161
    {
        public EventID ID => EventID.OnPlaceWard;
    }
    public class OnKillWard : ArgsBase, IEventEmptyHistory // 162
    {
        public EventID ID => EventID.OnKillWard;
    }
    public class OnMinionAscended : ArgsBase, IEventEmptyHistory // 163
    {
        public EventID ID => EventID.OnMinionAscended;
    }
    public class OnChampionAscended : ArgsBase, IEventEmptyHistory // 164
    {
        public EventID ID => EventID.OnChampionAscended;
    }
    public class OnClearAscended : ArgsBase, IEventEmptyHistory // 165
    {
        public EventID ID => EventID.OnClearAscended;
    }
    public class OnGameStatEvent : ArgsBase, IEventEmptyHistory // 166
    {
        public EventID ID => EventID.OnGameStatEvent;
    }
}
