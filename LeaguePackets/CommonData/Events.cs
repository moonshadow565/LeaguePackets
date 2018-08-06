using System;
using LeaguePackets.Common;
using System.Collections.Generic;
using LeaguePackets.CommonData.Events;
namespace LeaguePackets.CommonData
{
    public class EventDelete : EventBase<ArgsBase> //0
    { 
        public override EventID EventID => EventID.Delete;
    }
    public class EventSpawn : EventBase<ArgsDie> //1
    { 
        public override EventID EventID => EventID.Spawn;
    }
    public class EventDie : EventBase<ArgsDie> //2
    { 
        public override EventID EventID => EventID.Die;
    }
    public class EventKill : EventBase<ArgsBase> //3
    { 
        public override EventID EventID => EventID.Kill;
    }
    public class EventChampionDie : EventBase<ArgsBase> //4
    { 
        public override EventID EventID => EventID.ChampionDie;
    }
    public class EventChampionKillPre : EventBase<ArgsChampionKillPre> //5
    { 
        public override EventID EventID => EventID.ChampionKillPre;
    }
    public class EventChampionKill : EventBase<ArgsBase> //6
    { 
        public override EventID EventID => EventID.ChampionKill;
    }
    public class EventChampionKillPost : EventBase<ArgsBase> //7
    { 
        public override EventID EventID => EventID.ChampionKillPost;
    }
    public class EventChampionSinglekill : EventBase<ArgsBase> //8
    { 
        public override EventID EventID => EventID.ChampionSinglekill;
    }
    public class EventChampionDoublekill : EventBase<ArgsBase> //9
    { 
        public override EventID EventID => EventID.ChampionDoublekill;
    }
    public class EventChampionTriplekill : EventBase<ArgsBase> //10
    { 
        public override EventID EventID => EventID.ChampionTriplekill;
    }
    public class EventChampionQuadrakill : EventBase<ArgsBase> //11
    { 
        public override EventID EventID => EventID.ChampionQuadrakill;
    }
    public class EventChampionPentakill : EventBase<ArgsBase> //12
    { 
        public override EventID EventID => EventID.ChampionPentakill;
    }
    public class EventChampionUnrealkill : EventBase<ArgsBase> //13
    { 
        public override EventID EventID => EventID.ChampionUnrealkill;
    }
    public class EventFirstblood : EventBase<ArgsBase> //14
    { 
        public override EventID EventID => EventID.Firstblood;
    }
    public class EventDamageTaken : EventBase<ArgsDamage> //15
    { 
        public override EventID EventID => EventID.DamageTaken;
    }
    public class EventDamageGiven : EventBase<ArgsDamage> //16
    { 
        public override EventID EventID => EventID.DamageGiven;
    }
    public class EventSpellCast1 : EventBase<ArgsBase> //17
    { 
        public override EventID EventID => EventID.SpellCast1;
    }
    public class EventSpellCast2 : EventBase<ArgsBase> //18
    { 
        public override EventID EventID => EventID.SpellCast2;
    }
    public class EventSpellCast3 : EventBase<ArgsBase> //19
    { 
        public override EventID EventID => EventID.SpellCast3;
    }
    public class EventSpellCast4 : EventBase<ArgsBase> //20
    { 
        public override EventID EventID => EventID.SpellCast4;
    }
    public class EventSpellAvatarCast1 : EventBase<ArgsBase> //21
    { 
        public override EventID EventID => EventID.SpellAvatarCast1;
    }
    public class EventSpellAvatarCast2 : EventBase<ArgsBase> //22
    { 
        public override EventID EventID => EventID.SpellAvatarCast2;
    }
    public class EventGoldSpent : EventBase<ArgsGoldSpent> //23
    { 
        public override EventID EventID => EventID.GoldSpent;
    }
    public class EventGoldEarned : EventBase<ArgsGoldEarned> //24
    { 
        public override EventID EventID => EventID.GoldEarned;
    }
    public class EventItemConsumeablePurchased : EventBase<ArgsItemConsumedPurchased> //25
    { 
        public override EventID EventID => EventID.ItemConsumeablePurchased;
    }
    public class EventCriticalStrike : EventBase<ArgsDamageCriticalStrike> //26
    { 
        public override EventID EventID => EventID.CriticalStrike;
    }
    public class EventAce : EventBase<ArgsBase> //27
    { 
        public override EventID EventID => EventID.Ace;
    }
    public class EventReincarnate : EventBase<ArgsBase> //28
    { 
        public override EventID EventID => EventID.Reincarnate;
    }
    public class EventChangeChampion : EventBase<ArgsBase> //29
    { 
        public override EventID EventID => EventID.ChangeChampion;
    }
    public class EventDampenerKill : EventBase<ArgsBase> //30
    { 
        public override EventID EventID => EventID.DampenerKill;
    }
    public class EventDampenerDie : EventBase<ArgsBase> //31
    { 
        public override EventID EventID => EventID.DampenerDie;
    }
    public class EventDampenerRespawnSoon : EventBase<ArgsBase> //32
    { 
        public override EventID EventID => EventID.DampenerRespawnSoon;
    }
    public class EventDampenerRespawn : EventBase<ArgsBase> //33
    { 
        public override EventID EventID => EventID.DampenerRespawn;
    }
    public class EventDampenerDamage : EventBase<ArgsBase> //34
    { 
        public override EventID EventID => EventID.DampenerDamage;
    }
    public class EventTurretKill : EventBase<ArgsBase> //35
    { 
        public override EventID EventID => EventID.TurretKill;
    }
    public class EventTurretDie : EventBase<ArgsDie> //36
    { 
        public override EventID EventID => EventID.TurretDie;
    }
    public class EventTurretDamage : EventBase<ArgsDie> //37
    { 
        public override EventID EventID => EventID.TurretDamage;
    }
    public class EventMinionKill : EventBase<ArgsDie> //38
    { 
        public override EventID EventID => EventID.MinionKill;
    }
    public class EventMinionDenied : EventBase<ArgsBase> //39
    { 
        public override EventID EventID => EventID.MinionDenied;
    }
    public class EventNeutralMinionKill : EventBase<ArgsMinionKill> //40
    { 
        public override EventID EventID => EventID.NeutralMinionKill;
    }
    public class EventSuperMonsterKill : EventBase<ArgsBase> //41
    { 
        public override EventID EventID => EventID.SuperMonsterKill;
    }
    public class EventAcquireRedBuffFromNeutral : EventBase<ArgsBase> //42
    { 
        public override EventID EventID => EventID.AcquireRedBuffFromNeutral;
    }
    public class EventAcquireBlueBuffFromNeutral : EventBase<ArgsBase> //43
    { 
        public override EventID EventID => EventID.AcquireBlueBuffFromNeutral;
    }
    public class EventHqDie : EventBase<ArgsBase> //44
    { 
        public override EventID EventID => EventID.HqDie;
    }
    public class EventHqKill : EventBase<ArgsBase> //45
    { 
        public override EventID EventID => EventID.HqKill;
    }
    public class EventHeal : EventBase<ArgsHeal> //46
    { 
        public override EventID EventID => EventID.Heal;
    }
    public class EventCastHeal : EventBase<ArgsHeal> //47
    { 
        public override EventID EventID => EventID.CastHeal;
    }
    public class EventBuff : EventBase<ArgsBuff> //48
    { 
        public override EventID EventID => EventID.Buff;
    }
    public class EventCrowdControlDealt : EventBase<ArgsCC> //49
    { 
        public override EventID EventID => EventID.CrowdControlDealt;
    }
    public class EventKillingSpree : EventBase<ArgsKillingSpree> //50
    { 
        public override EventID EventID => EventID.KillingSpree;
    }
    public class EventKillingSpreeSet1 : EventBase<ArgsBase> //51
    { 
        public override EventID EventID => EventID.KillingSpreeSet1;
    }
    public class EventKillingSpreeSet2 : EventBase<ArgsBase> //52
    { 
        public override EventID EventID => EventID.KillingSpreeSet2;
    }
    public class EventKillingSpreeSet3 : EventBase<ArgsBase> //53
    { 
        public override EventID EventID => EventID.KillingSpreeSet3;
    }
    public class EventKillingSpreeSet4 : EventBase<ArgsBase> //54
    { 
        public override EventID EventID => EventID.KillingSpreeSet4;
    }
    public class EventKillingSpreeSet5 : EventBase<ArgsBase> //55
    { 
        public override EventID EventID => EventID.KillingSpreeSet5;
    }
    public class EventKillingSpreeSet6 : EventBase<ArgsBase> //56
    { 
        public override EventID EventID => EventID.KillingSpreeSet6;
    }
    public class EventKilledUnitOnKillingSpree : EventBase<ArgsBase> //57
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpree;
    }
    public class EventKilledUnitOnKillingSpreeSet1 : EventBase<ArgsBase> //58
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet1;
    }
    public class EventKilledUnitOnKillingSpreeSet2 : EventBase<ArgsBase> //59
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet2;
    }
    public class EventKilledUnitOnKillingSpreeSet3 : EventBase<ArgsBase> //60
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet3;
    }
    public class EventKilledUnitOnKillingSpreeSet4 : EventBase<ArgsBase> //61
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet4;
    }
    public class EventKilledUnitOnKillingSpreeSet5 : EventBase<ArgsBase> //62
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet5;
    }
    public class EventKilledUnitOnKillingSpreeSet6 : EventBase<ArgsBase> //63
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet6;
    }
    public class EventKilledUnitOnKillingSpreeDoublekill : EventBase<ArgsBase> //64
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeDoublekill;
    }
    public class EventKilledUnitOnKillingSpreeTriplekill : EventBase<ArgsBase> //65
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeTriplekill;
    }
    public class EventKilledUnitOnKillingSpreeQuadrakill : EventBase<ArgsBase> //66
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeQuadrakill;
    }
    public class EventKilledUnitOnKillingSpreePentakill : EventBase<ArgsBase> //67
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreePentakill;
    }
    public class EventKilledUnitOnKillingSpreeUnrealkill : EventBase<ArgsBase> //68
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeUnrealkill;
    }
    public class EventDeathAssist : EventBase<ArgsAssist> //69
    { 
        public override EventID EventID => EventID.DeathAssist;
    }
    public class EventQuit : EventBase<ArgsBase> //70
    { 
        public override EventID EventID => EventID.Quit;
    }
    public class EventLeave : EventBase<ArgsBase> //71
    { 
        public override EventID EventID => EventID.Leave;
    }
    public class EventReconnect : EventBase<ArgsBase> //72
    { 
        public override EventID EventID => EventID.Reconnect;
    }
    public class EventGameEnter : EventBase<ArgsBase> //73
    { 
        public override EventID EventID => EventID.GameEnter;
    }
    public class EventAssistingSpreeSet1 : EventBase<ArgsBase> //74
    { 
        public override EventID EventID => EventID.AssistingSpreeSet1;
    }
    public class EventAssistingSpreeSet2 : EventBase<ArgsBase> //75
    { 
        public override EventID EventID => EventID.AssistingSpreeSet2;
    }
    public class EventTripleAssist : EventBase<ArgsBase> //76
    { 
        public override EventID EventID => EventID.TripleAssist;
    }
    public class EventPentaAssist : EventBase<ArgsBase> //77
    { 
        public override EventID EventID => EventID.PentaAssist;
    }
    public class EventPing : EventBase<ArgsBase> //78
    { 
        public override EventID EventID => EventID.Ping;
    }
    public class EventPingPlayer : EventBase<ArgsBase> //79
    { 
        public override EventID EventID => EventID.PingPlayer;
    }
    public class EventPingBuilding : EventBase<ArgsBase> //80
    { 
        public override EventID EventID => EventID.PingBuilding;
    }
    public class EventPingOther : EventBase<ArgsBase> //81
    { 
        public override EventID EventID => EventID.PingOther;
    }
    public class EventEndGame : EventBase<ArgsBase> //82
    { 
        public override EventID EventID => EventID.EndGame;
    }
    public class EventSpellLevelup1 : EventBase<ArgsBase> //83
    { 
        public override EventID EventID => EventID.SpellLevelup1;
    }
    public class EventSpellLevelup2 : EventBase<ArgsBase> //84
    { 
        public override EventID EventID => EventID.SpellLevelup2;
    }
    public class EventSpellLevelup3 : EventBase<ArgsBase> //85
    { 
        public override EventID EventID => EventID.SpellLevelup3;
    }
    public class EventSpellLevelup4 : EventBase<ArgsBase> //86
    { 
        public override EventID EventID => EventID.SpellLevelup4;
    }
    public class EventSpellEvolve1 : EventBase<ArgsBase> //87
    { 
        public override EventID EventID => EventID.SpellEvolve1;
    }
    public class EventSpellEvolve2 : EventBase<ArgsBase> //88
    { 
        public override EventID EventID => EventID.SpellEvolve2;
    }
    public class EventSpellEvolve3 : EventBase<ArgsBase> //89
    { 
        public override EventID EventID => EventID.SpellEvolve3;
    }
    public class EventSpellEvolve4 : EventBase<ArgsBase> //90
    { 
        public override EventID EventID => EventID.SpellEvolve4;
    }
    public class EventItemPurchased : EventBase<ArgsItemConsumedPurchased> //91
    { 
        public override EventID EventID => EventID.ItemPurchased;
    }
    public class EventItemSold : EventBase<ArgsItemSoldOrRemoved> //92
    { 
        public override EventID EventID => EventID.ItemSold;
    }
    public class EventItemRemoved : EventBase<ArgsItemSoldOrRemoved> //93
    { 
        public override EventID EventID => EventID.ItemRemoved;
    }
    public class EventItemUndo : EventBase<ArgsItemUndo> //94
    { 
        public override EventID EventID => EventID.ItemUndo;
    }
    public class EventItemCallout : EventBase<ArgsItemCallout> //95
    { 
        public override EventID EventID => EventID.ItemCallout;
    }
    public class EventItemClientChange : EventBase<ArgsItemChange> //96
    { 
        public override EventID EventID => EventID.ItemClientChange;
    }
    public class EventUndoEnabledChange : EventBase<ArgsUndoEnabledChange> //97
    { 
        public override EventID EventID => EventID.UndoEnabledChange;
    }
    public class EventShopItemSubstitutionChange : EventBase<ArgsShopItemSubstitutionChange> //98
    { 
        public override EventID EventID => EventID.ShopItemSubstitutionChange;
    }
    public class EventSurrenderVoteStart : EventBase<ArgsSurrenderVotes> //99 check this
    { 
        public override EventID EventID => EventID.SurrenderVoteStart;
    }
    public class EventSurrenderVote : EventBase<ArgsSurrenderVotes> //100 check this
    { 
        public override EventID EventID => EventID.SurrenderVote;
    }
    public class EventSurrenderVoteAlready : EventBase<ArgsBase> //101
    { 
        public override EventID EventID => EventID.SurrenderVoteAlready;
    }
    public class EventSurrenderFailedVotes : EventBase<ArgsSurrenderVotes> //102 check this
    { 
        public override EventID EventID => EventID.SurrenderFailedVotes;
    }
    public class EventSurrenderFailedTooEarly : EventBase<ArgsBase> //103
    { 
        public override EventID EventID => EventID.SurrenderFailedTooEarly;
    }
    public class EventSurrenderAgreed : EventBase<ArgsSurrenderVotes> //104 check this
    { 
        public override EventID EventID => EventID.SurrenderAgreed;
    }
    public class EventSurrenderSpam : EventBase<ArgsSurrenderVotes> //105 check this
    { 
        public override EventID EventID => EventID.SurrenderSpam;
    }
    public class EventEarlySurrenderAllowed : EventBase<ArgsBase> //106
    { 
        public override EventID EventID => EventID.EarlySurrenderAllowed;
    }
    public class EventEqualizeVoteStart : EventBase<ArgsEqualizeVotes> //107 check this
    { 
        public override EventID EventID => EventID.EqualizeVoteStart;
    }
    public class EventEqualizeVote : EventBase<ArgsEqualizeVotes> //108 check this
    { 
        public override EventID EventID => EventID.EqualizeVote;
    }
    public class EventEqualizeVoteAlready : EventBase<ArgsBase> //109
    { 
        public override EventID EventID => EventID.EqualizeVoteAlready;
    }
    public class EventEqualizeFailedVotes : EventBase<ArgsEqualizeVotes> //110 check this
    { 
        public override EventID EventID => EventID.EqualizeFailedVotes;
    }
    public class EventEqualizeFailedTooEarly : EventBase<ArgsBase> //111
    { 
        public override EventID EventID => EventID.EqualizeFailedTooEarly;
    }
    public class EventEqualizeFailedNoGoldLead : EventBase<ArgsBase> //112
    { 
        public override EventID EventID => EventID.EqualizeFailedNoGoldLead;
    }
    public class EventEqualizeFailedNoLevelLead : EventBase<ArgsBase> //113
    { 
        public override EventID EventID => EventID.EqualizeFailedNoLevelLead;
    }
    public class EventEqualizeAgreed : EventBase<ArgsEqualizeVotes> //114 check this
    { 
        public override EventID EventID => EventID.EqualizeAgreed;
    }
    public class EventEqualizeSpam : EventBase<ArgsEqualizeVotes> //115 check this
    { 
        public override EventID EventID => EventID.EqualizeSpam;
    }
    public class EventPause : EventBase<ArgsBase> //116
    { 
        public override EventID EventID => EventID.Pause;
    }
    public class EventPauseResume : EventBase<ArgsBase> //117
    { 
        public override EventID EventID => EventID.PauseResume;
    }
    public class EventMinionsSpawn : EventBase<ArgsBase> //118
    { 
        public override EventID EventID => EventID.MinionsSpawn;
    }
    public class EventStartGameMessage1 : EventBase<ArgsBase> //119
    { 
        public override EventID EventID => EventID.StartGameMessage1;
    }
    public class EventStartGameMessage2 : EventBase<ArgsBase> //120
    { 
        public override EventID EventID => EventID.StartGameMessage2;
    }
    public class EventStartGameMessage3 : EventBase<ArgsBase> //121
    { 
        public override EventID EventID => EventID.StartGameMessage3;
    }
    public class EventStartGameMessage4 : EventBase<ArgsBase> //122
    { 
        public override EventID EventID => EventID.StartGameMessage4;
    }
    public class EventStartGameMessage5 : EventBase<ArgsBase> //123
    { 
        public override EventID EventID => EventID.StartGameMessage5;
    }
    public class EventAlert : EventBase<ArgsAlert> //124 check this
    { 
        public override EventID EventID => EventID.Alert;
    }
    public class EventScoreboardOpen : EventBase<ArgsBase> //125
    { 
        public override EventID EventID => EventID.ScoreboardOpen;
    }
    public class EventAudioEventFinished : EventBase<ArgsBase> //126
    { 
        public override EventID EventID => EventID.AudioEventFinished;
    }
    public class EventNexusCrystalStart : EventBase<ArgsBase> //127
    { 
        public override EventID EventID => EventID.NexusCrystalStart;
    }
    public class EventCapturePointNeutralizedA : EventBase<ArgsCapturePoint> //128
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedA;
    }
    public class EventCapturePointNeutralizedB : EventBase<ArgsCapturePoint> //129
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedB;
    }
    public class EventCapturePointNeutralizedC : EventBase<ArgsCapturePoint> //130
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedC;
    }
    public class EventCapturePointNeutralizedD : EventBase<ArgsCapturePoint> //131
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedD;
    }
    public class EventCapturePointNeutralizedE : EventBase<ArgsCapturePoint> //132
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedE;
    }
    public class EventCapturePointCapturedA : EventBase<ArgsCapturePoint> //133
    { 
        public override EventID EventID => EventID.CapturePointCapturedA;
    }
    public class EventCapturePointCapturedB : EventBase<ArgsCapturePoint> //134
    { 
        public override EventID EventID => EventID.CapturePointCapturedB;
    }
    public class EventCapturePointCapturedC : EventBase<ArgsCapturePoint> //135
    { 
        public override EventID EventID => EventID.CapturePointCapturedC;
    }
    public class EventCapturePointCapturedD : EventBase<ArgsCapturePoint> //136
    { 
        public override EventID EventID => EventID.CapturePointCapturedD;
    }
    public class EventCapturePointCapturedE : EventBase<ArgsCapturePoint> //137
    { 
        public override EventID EventID => EventID.CapturePointCapturedE;
    }
    public class EventCapturePointFiveCap : EventBase<ArgsBase> //138
    { 
        public override EventID EventID => EventID.CapturePointFiveCap;
    }
    public class EventVictoryPointThreshold1 : EventBase<ArgsCapturePoint> //139
    { 
        public override EventID EventID => EventID.VictoryPointThreshold1;
    }
    public class EventVictoryPointThreshold2 : EventBase<ArgsCapturePoint> //140
    { 
        public override EventID EventID => EventID.VictoryPointThreshold2;
    }
    public class EventVictoryPointThreshold3 : EventBase<ArgsCapturePoint> //141
    { 
        public override EventID EventID => EventID.VictoryPointThreshold3;
    }
    public class EventVictoryPointThreshold4 : EventBase<ArgsCapturePoint> //142
    { 
        public override EventID EventID => EventID.VictoryPointThreshold4;
    }
    public class EventMinionKillVictoryThreshold1 : EventBase<ArgsBase> //143
    { 
        public override EventID EventID => EventID.MinionKillVictoryThreshold1;
    }
    public class EventMinionKillVictoryThreshold2 : EventBase<ArgsBase> //144
    { 
        public override EventID EventID => EventID.MinionKillVictoryThreshold2;
    }
    public class EventTurretKillVictoryThreshold1 : EventBase<ArgsBase> //145
    { 
        public override EventID EventID => EventID.TurretKillVictoryThreshold1;
    }
    public class EventTurretKillVictoryThreshold2 : EventBase<ArgsBase> //146
    { 
        public override EventID EventID => EventID.TurretKillVictoryThreshold2;
    }
    public class EventReplayFastForwardStart : EventBase<ArgsBase> //147
    { 
        public override EventID EventID => EventID.ReplayFastForwardStart;
    }
    public class EventReplayFastForwardEnd : EventBase<ArgsBase> //148
    { 
        public override EventID EventID => EventID.ReplayFastForwardEnd;
    }
    public class EventReplayOnKeyframeFinished : EventBase<ArgsBase> //149
    { 
        public override EventID EventID => EventID.ReplayOnKeyframeFinished;
    }
    public class EventReplayDestroyAllObjects : EventBase<ArgsBase> //150
    { 
        public override EventID EventID => EventID.ReplayDestroyAllObjects;
    }
    public class EventKillDragon : EventBase<ArgsMinionKill> //151
    { 
        public override EventID EventID => EventID.KillDragon;
    }
    public class EventKillDragonSpectator : EventBase<ArgsMinionKill> //152
    { 
        public override EventID EventID => EventID.KillDragonSpectator;
    }
    public class EventKillDragonSteal : EventBase<ArgsMinionKill> //153
    { 
        public override EventID EventID => EventID.KillDragonSteal;
    }
    public class EventKillWorm : EventBase<ArgsMinionKill> //154
    { 
        public override EventID EventID => EventID.KillWorm;
    }
    public class EventKillWormSpectator : EventBase<ArgsMinionKill> //155
    { 
        public override EventID EventID => EventID.KillWormSpectator;
    }
    public class EventKillWormSteal : EventBase<ArgsMinionKill> //156
    { 
        public override EventID EventID => EventID.KillWormSteal;
    }
    public class EventKillSpiderboss : EventBase<ArgsMinionKill> //157
    { 
        public override EventID EventID => EventID.KillSpiderboss;
    }
    public class EventKillSpiderbossSpectator : EventBase<ArgsMinionKill> //158
    { 
        public override EventID EventID => EventID.KillSpiderbossSpectator;
    }
    public class EventCaptureAltar : EventBase<ArgsCapturePoint> //159
    { 
        public override EventID EventID => EventID.CaptureAltar;
    }
    public class EventCaptureAltarSpectator : EventBase<ArgsCapturePoint> //160
    { 
        public override EventID EventID => EventID.CaptureAltarSpectator;
    }
    public class EventPlaceWard : EventBase<ArgsBase> //161
    { 
        public override EventID EventID => EventID.PlaceWard;
    }
    public class EventKillWard : EventBase<ArgsBase> //162
    { 
        public override EventID EventID => EventID.KillWard;
    }
    public class EventMinionAscended : EventBase<ArgsBase> //163
    { 
        public override EventID EventID => EventID.MinionAscended;
    }
    public class EventChampionAscended : EventBase<ArgsBase> //164
    { 
        public override EventID EventID => EventID.ChampionAscended;
    }
    public class EventClearAscended : EventBase<ArgsBase> //165
    { 
        public override EventID EventID => EventID.ClearAscended;
    }
    public class EventGameStat : EventBase<ArgsBase> //166
    { 
        public override EventID EventID => EventID.GameStat;
    }
}
