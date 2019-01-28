using System;
using System.Collections.Generic;
namespace LeaguePackets.Game.Events
{
    public class EventDelete : Event<ArgsBase> //0
    { 
        public override EventID EventID => EventID.Delete;
    }
    public class EventSpawn : Event<ArgsDie> //1
    { 
        public override EventID EventID => EventID.Spawn;
    }
    public class EventDie : Event<ArgsDie> //2
    { 
        public override EventID EventID => EventID.Die;
    }
    public class EventKill : Event<ArgsBase> //3
    { 
        public override EventID EventID => EventID.Kill;
    }
    public class EventChampionDie : Event<ArgsBase> //4
    { 
        public override EventID EventID => EventID.ChampionDie;
    }
    public class EventChampionKillPre : Event<ArgsChampionKillPre> //5
    { 
        public override EventID EventID => EventID.ChampionKillPre;
    }
    public class EventChampionKill : Event<ArgsBase> //6
    { 
        public override EventID EventID => EventID.ChampionKill;
    }
    public class EventChampionKillPost : Event<ArgsBase> //7
    { 
        public override EventID EventID => EventID.ChampionKillPost;
    }
    public class EventChampionSinglekill : Event<ArgsBase> //8
    { 
        public override EventID EventID => EventID.ChampionSinglekill;
    }
    public class EventChampionDoublekill : Event<ArgsBase> //9
    { 
        public override EventID EventID => EventID.ChampionDoublekill;
    }
    public class EventChampionTriplekill : Event<ArgsBase> //10
    { 
        public override EventID EventID => EventID.ChampionTriplekill;
    }
    public class EventChampionQuadrakill : Event<ArgsBase> //11
    { 
        public override EventID EventID => EventID.ChampionQuadrakill;
    }
    public class EventChampionPentakill : Event<ArgsBase> //12
    { 
        public override EventID EventID => EventID.ChampionPentakill;
    }
    public class EventChampionUnrealkill : Event<ArgsBase> //13
    { 
        public override EventID EventID => EventID.ChampionUnrealkill;
    }
    public class EventFirstblood : Event<ArgsBase> //14
    { 
        public override EventID EventID => EventID.Firstblood;
    }
    public class EventDamageTaken : Event<ArgsDamage> //15
    { 
        public override EventID EventID => EventID.DamageTaken;
    }
    public class EventDamageGiven : Event<ArgsDamage> //16
    { 
        public override EventID EventID => EventID.DamageGiven;
    }
    public class EventSpellCast1 : Event<ArgsBase> //17
    { 
        public override EventID EventID => EventID.SpellCast1;
    }
    public class EventSpellCast2 : Event<ArgsBase> //18
    { 
        public override EventID EventID => EventID.SpellCast2;
    }
    public class EventSpellCast3 : Event<ArgsBase> //19
    { 
        public override EventID EventID => EventID.SpellCast3;
    }
    public class EventSpellCast4 : Event<ArgsBase> //20
    { 
        public override EventID EventID => EventID.SpellCast4;
    }
    public class EventSpellAvatarCast1 : Event<ArgsBase> //21
    { 
        public override EventID EventID => EventID.SpellAvatarCast1;
    }
    public class EventSpellAvatarCast2 : Event<ArgsBase> //22
    { 
        public override EventID EventID => EventID.SpellAvatarCast2;
    }
    public class EventGoldSpent : Event<ArgsGoldSpent> //23
    { 
        public override EventID EventID => EventID.GoldSpent;
    }
    public class EventGoldEarned : Event<ArgsGoldEarned> //24
    { 
        public override EventID EventID => EventID.GoldEarned;
    }
    public class EventItemConsumeablePurchased : Event<ArgsItemConsumedPurchased> //25
    { 
        public override EventID EventID => EventID.ItemConsumeablePurchased;
    }
    public class EventCriticalStrike : Event<ArgsDamageCriticalStrike> //26
    { 
        public override EventID EventID => EventID.CriticalStrike;
    }
    public class EventAce : Event<ArgsBase> //27
    { 
        public override EventID EventID => EventID.Ace;
    }
    public class EventReincarnate : Event<ArgsBase> //28
    { 
        public override EventID EventID => EventID.Reincarnate;
    }
    public class EventChangeChampion : Event<ArgsBase> //29
    { 
        public override EventID EventID => EventID.ChangeChampion;
    }
    public class EventDampenerKill : Event<ArgsBase> //30
    { 
        public override EventID EventID => EventID.DampenerKill;
    }
    public class EventDampenerDie : Event<ArgsBase> //31
    { 
        public override EventID EventID => EventID.DampenerDie;
    }
    public class EventDampenerRespawnSoon : Event<ArgsBase> //32
    { 
        public override EventID EventID => EventID.DampenerRespawnSoon;
    }
    public class EventDampenerRespawn : Event<ArgsBase> //33
    { 
        public override EventID EventID => EventID.DampenerRespawn;
    }
    public class EventDampenerDamage : Event<ArgsBase> //34
    { 
        public override EventID EventID => EventID.DampenerDamage;
    }
    public class EventTurretKill : Event<ArgsBase> //35
    { 
        public override EventID EventID => EventID.TurretKill;
    }
    public class EventTurretDie : Event<ArgsDie> //36
    { 
        public override EventID EventID => EventID.TurretDie;
    }
    public class EventTurretDamage : Event<ArgsDie> //37
    { 
        public override EventID EventID => EventID.TurretDamage;
    }
    public class EventMinionKill : Event<ArgsDie> //38
    { 
        public override EventID EventID => EventID.MinionKill;
    }
    public class EventMinionDenied : Event<ArgsBase> //39
    { 
        public override EventID EventID => EventID.MinionDenied;
    }
    public class EventNeutralMinionKill : Event<ArgsMinionKill> //40
    { 
        public override EventID EventID => EventID.NeutralMinionKill;
    }
    public class EventSuperMonsterKill : Event<ArgsBase> //41
    { 
        public override EventID EventID => EventID.SuperMonsterKill;
    }
    public class EventAcquireRedBuffFromNeutral : Event<ArgsBase> //42
    { 
        public override EventID EventID => EventID.AcquireRedBuffFromNeutral;
    }
    public class EventAcquireBlueBuffFromNeutral : Event<ArgsBase> //43
    { 
        public override EventID EventID => EventID.AcquireBlueBuffFromNeutral;
    }
    public class EventHqDie : Event<ArgsBase> //44
    { 
        public override EventID EventID => EventID.HqDie;
    }
    public class EventHqKill : Event<ArgsBase> //45
    { 
        public override EventID EventID => EventID.HqKill;
    }
    public class EventHeal : Event<ArgsHeal> //46
    { 
        public override EventID EventID => EventID.Heal;
    }
    public class EventCastHeal : Event<ArgsHeal> //47
    { 
        public override EventID EventID => EventID.CastHeal;
    }
    public class EventBuff : Event<ArgsBuff> //48
    { 
        public override EventID EventID => EventID.Buff;
    }
    public class EventCrowdControlDealt : Event<ArgsCC> //49
    { 
        public override EventID EventID => EventID.CrowdControlDealt;
    }
    public class EventKillingSpree : Event<ArgsKillingSpree> //50
    { 
        public override EventID EventID => EventID.KillingSpree;
    }
    public class EventKillingSpreeSet1 : Event<ArgsBase> //51
    { 
        public override EventID EventID => EventID.KillingSpreeSet1;
    }
    public class EventKillingSpreeSet2 : Event<ArgsBase> //52
    { 
        public override EventID EventID => EventID.KillingSpreeSet2;
    }
    public class EventKillingSpreeSet3 : Event<ArgsBase> //53
    { 
        public override EventID EventID => EventID.KillingSpreeSet3;
    }
    public class EventKillingSpreeSet4 : Event<ArgsBase> //54
    { 
        public override EventID EventID => EventID.KillingSpreeSet4;
    }
    public class EventKillingSpreeSet5 : Event<ArgsBase> //55
    { 
        public override EventID EventID => EventID.KillingSpreeSet5;
    }
    public class EventKillingSpreeSet6 : Event<ArgsBase> //56
    { 
        public override EventID EventID => EventID.KillingSpreeSet6;
    }
    public class EventKilledUnitOnKillingSpree : Event<ArgsBase> //57
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpree;
    }
    public class EventKilledUnitOnKillingSpreeSet1 : Event<ArgsBase> //58
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet1;
    }
    public class EventKilledUnitOnKillingSpreeSet2 : Event<ArgsBase> //59
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet2;
    }
    public class EventKilledUnitOnKillingSpreeSet3 : Event<ArgsBase> //60
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet3;
    }
    public class EventKilledUnitOnKillingSpreeSet4 : Event<ArgsBase> //61
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet4;
    }
    public class EventKilledUnitOnKillingSpreeSet5 : Event<ArgsBase> //62
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet5;
    }
    public class EventKilledUnitOnKillingSpreeSet6 : Event<ArgsBase> //63
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeSet6;
    }
    public class EventKilledUnitOnKillingSpreeDoublekill : Event<ArgsBase> //64
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeDoublekill;
    }
    public class EventKilledUnitOnKillingSpreeTriplekill : Event<ArgsBase> //65
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeTriplekill;
    }
    public class EventKilledUnitOnKillingSpreeQuadrakill : Event<ArgsBase> //66
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeQuadrakill;
    }
    public class EventKilledUnitOnKillingSpreePentakill : Event<ArgsBase> //67
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreePentakill;
    }
    public class EventKilledUnitOnKillingSpreeUnrealkill : Event<ArgsBase> //68
    { 
        public override EventID EventID => EventID.KilledUnitOnKillingSpreeUnrealkill;
    }
    public class EventDeathAssist : Event<ArgsAssist> //69
    { 
        public override EventID EventID => EventID.DeathAssist;
    }
    public class EventQuit : Event<ArgsBase> //70
    { 
        public override EventID EventID => EventID.Quit;
    }
    public class EventLeave : Event<ArgsBase> //71
    { 
        public override EventID EventID => EventID.Leave;
    }
    public class EventReconnect : Event<ArgsBase> //72
    { 
        public override EventID EventID => EventID.Reconnect;
    }
    public class EventGameEnter : Event<ArgsBase> //73
    { 
        public override EventID EventID => EventID.GameEnter;
    }
    public class EventAssistingSpreeSet1 : Event<ArgsBase> //74
    { 
        public override EventID EventID => EventID.AssistingSpreeSet1;
    }
    public class EventAssistingSpreeSet2 : Event<ArgsBase> //75
    { 
        public override EventID EventID => EventID.AssistingSpreeSet2;
    }
    public class EventTripleAssist : Event<ArgsBase> //76
    { 
        public override EventID EventID => EventID.TripleAssist;
    }
    public class EventPentaAssist : Event<ArgsBase> //77
    { 
        public override EventID EventID => EventID.PentaAssist;
    }
    public class EventPing : Event<ArgsBase> //78
    { 
        public override EventID EventID => EventID.Ping;
    }
    public class EventPingPlayer : Event<ArgsBase> //79
    { 
        public override EventID EventID => EventID.PingPlayer;
    }
    public class EventPingBuilding : Event<ArgsBase> //80
    { 
        public override EventID EventID => EventID.PingBuilding;
    }
    public class EventPingOther : Event<ArgsBase> //81
    { 
        public override EventID EventID => EventID.PingOther;
    }
    public class EventEndGame : Event<ArgsBase> //82
    { 
        public override EventID EventID => EventID.EndGame;
    }
    public class EventSpellLevelup1 : Event<ArgsBase> //83
    { 
        public override EventID EventID => EventID.SpellLevelup1;
    }
    public class EventSpellLevelup2 : Event<ArgsBase> //84
    { 
        public override EventID EventID => EventID.SpellLevelup2;
    }
    public class EventSpellLevelup3 : Event<ArgsBase> //85
    { 
        public override EventID EventID => EventID.SpellLevelup3;
    }
    public class EventSpellLevelup4 : Event<ArgsBase> //86
    { 
        public override EventID EventID => EventID.SpellLevelup4;
    }
    public class EventSpellEvolve1 : Event<ArgsBase> //87
    { 
        public override EventID EventID => EventID.SpellEvolve1;
    }
    public class EventSpellEvolve2 : Event<ArgsBase> //88
    { 
        public override EventID EventID => EventID.SpellEvolve2;
    }
    public class EventSpellEvolve3 : Event<ArgsBase> //89
    { 
        public override EventID EventID => EventID.SpellEvolve3;
    }
    public class EventSpellEvolve4 : Event<ArgsBase> //90
    { 
        public override EventID EventID => EventID.SpellEvolve4;
    }
    public class EventItemPurchased : Event<ArgsItemConsumedPurchased> //91
    { 
        public override EventID EventID => EventID.ItemPurchased;
    }
    public class EventItemSold : Event<ArgsItemSoldOrRemoved> //92
    { 
        public override EventID EventID => EventID.ItemSold;
    }
    public class EventItemRemoved : Event<ArgsItemSoldOrRemoved> //93
    { 
        public override EventID EventID => EventID.ItemRemoved;
    }
    public class EventItemUndo : Event<ArgsItemUndo> //94
    { 
        public override EventID EventID => EventID.ItemUndo;
    }
    public class EventItemCallout : Event<ArgsItemCallout> //95
    { 
        public override EventID EventID => EventID.ItemCallout;
    }
    public class EventItemClientChange : Event<ArgsItemChange> //96
    { 
        public override EventID EventID => EventID.ItemClientChange;
    }
    public class EventUndoEnabledChange : Event<ArgsUndoEnabledChange> //97
    { 
        public override EventID EventID => EventID.UndoEnabledChange;
    }
    public class EventShopItemSubstitutionChange : Event<ArgsShopItemSubstitutionChange> //98
    { 
        public override EventID EventID => EventID.ShopItemSubstitutionChange;
    }
    public class EventSurrenderVoteStart : Event<ArgsSurrenderVotes> //99 check this
    { 
        public override EventID EventID => EventID.SurrenderVoteStart;
    }
    public class EventSurrenderVote : Event<ArgsSurrenderVotes> //100 check this
    { 
        public override EventID EventID => EventID.SurrenderVote;
    }
    public class EventSurrenderVoteAlready : Event<ArgsBase> //101
    { 
        public override EventID EventID => EventID.SurrenderVoteAlready;
    }
    public class EventSurrenderFailedVotes : Event<ArgsSurrenderVotes> //102 check this
    { 
        public override EventID EventID => EventID.SurrenderFailedVotes;
    }
    public class EventSurrenderFailedTooEarly : Event<ArgsBase> //103
    { 
        public override EventID EventID => EventID.SurrenderFailedTooEarly;
    }
    public class EventSurrenderAgreed : Event<ArgsSurrenderVotes> //104 check this
    { 
        public override EventID EventID => EventID.SurrenderAgreed;
    }
    public class EventSurrenderSpam : Event<ArgsSurrenderVotes> //105 check this
    { 
        public override EventID EventID => EventID.SurrenderSpam;
    }
    public class EventEarlySurrenderAllowed : Event<ArgsBase> //106
    { 
        public override EventID EventID => EventID.EarlySurrenderAllowed;
    }
    public class EventEqualizeVoteStart : Event<ArgsEqualizeVotes> //107 check this
    { 
        public override EventID EventID => EventID.EqualizeVoteStart;
    }
    public class EventEqualizeVote : Event<ArgsEqualizeVotes> //108 check this
    { 
        public override EventID EventID => EventID.EqualizeVote;
    }
    public class EventEqualizeVoteAlready : Event<ArgsBase> //109
    { 
        public override EventID EventID => EventID.EqualizeVoteAlready;
    }
    public class EventEqualizeFailedVotes : Event<ArgsEqualizeVotes> //110 check this
    { 
        public override EventID EventID => EventID.EqualizeFailedVotes;
    }
    public class EventEqualizeFailedTooEarly : Event<ArgsBase> //111
    { 
        public override EventID EventID => EventID.EqualizeFailedTooEarly;
    }
    public class EventEqualizeFailedNoGoldLead : Event<ArgsBase> //112
    { 
        public override EventID EventID => EventID.EqualizeFailedNoGoldLead;
    }
    public class EventEqualizeFailedNoLevelLead : Event<ArgsBase> //113
    { 
        public override EventID EventID => EventID.EqualizeFailedNoLevelLead;
    }
    public class EventEqualizeAgreed : Event<ArgsEqualizeVotes> //114 check this
    { 
        public override EventID EventID => EventID.EqualizeAgreed;
    }
    public class EventEqualizeSpam : Event<ArgsEqualizeVotes> //115 check this
    { 
        public override EventID EventID => EventID.EqualizeSpam;
    }
    public class EventPause : Event<ArgsBase> //116
    { 
        public override EventID EventID => EventID.Pause;
    }
    public class EventPauseResume : Event<ArgsBase> //117
    { 
        public override EventID EventID => EventID.PauseResume;
    }
    public class EventMinionsSpawn : Event<ArgsBase> //118
    { 
        public override EventID EventID => EventID.MinionsSpawn;
    }
    public class EventStartGameMessage1 : Event<ArgsBase> //119
    { 
        public override EventID EventID => EventID.StartGameMessage1;
    }
    public class EventStartGameMessage2 : Event<ArgsBase> //120
    { 
        public override EventID EventID => EventID.StartGameMessage2;
    }
    public class EventStartGameMessage3 : Event<ArgsBase> //121
    { 
        public override EventID EventID => EventID.StartGameMessage3;
    }
    public class EventStartGameMessage4 : Event<ArgsBase> //122
    { 
        public override EventID EventID => EventID.StartGameMessage4;
    }
    public class EventStartGameMessage5 : Event<ArgsBase> //123
    { 
        public override EventID EventID => EventID.StartGameMessage5;
    }
    public class EventAlert : Event<ArgsAlert> //124 check this
    { 
        public override EventID EventID => EventID.Alert;
    }
    public class EventScoreboardOpen : Event<ArgsBase> //125
    { 
        public override EventID EventID => EventID.ScoreboardOpen;
    }
    public class EventAudioEventFinished : Event<ArgsBase> //126
    { 
        public override EventID EventID => EventID.AudioEventFinished;
    }
    public class EventNexusCrystalStart : Event<ArgsBase> //127
    { 
        public override EventID EventID => EventID.NexusCrystalStart;
    }
    public class EventCapturePointNeutralizedA : Event<ArgsCapturePoint> //128
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedA;
    }
    public class EventCapturePointNeutralizedB : Event<ArgsCapturePoint> //129
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedB;
    }
    public class EventCapturePointNeutralizedC : Event<ArgsCapturePoint> //130
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedC;
    }
    public class EventCapturePointNeutralizedD : Event<ArgsCapturePoint> //131
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedD;
    }
    public class EventCapturePointNeutralizedE : Event<ArgsCapturePoint> //132
    { 
        public override EventID EventID => EventID.CapturePointNeutralizedE;
    }
    public class EventCapturePointCapturedA : Event<ArgsCapturePoint> //133
    { 
        public override EventID EventID => EventID.CapturePointCapturedA;
    }
    public class EventCapturePointCapturedB : Event<ArgsCapturePoint> //134
    { 
        public override EventID EventID => EventID.CapturePointCapturedB;
    }
    public class EventCapturePointCapturedC : Event<ArgsCapturePoint> //135
    { 
        public override EventID EventID => EventID.CapturePointCapturedC;
    }
    public class EventCapturePointCapturedD : Event<ArgsCapturePoint> //136
    { 
        public override EventID EventID => EventID.CapturePointCapturedD;
    }
    public class EventCapturePointCapturedE : Event<ArgsCapturePoint> //137
    { 
        public override EventID EventID => EventID.CapturePointCapturedE;
    }
    public class EventCapturePointFiveCap : Event<ArgsBase> //138
    { 
        public override EventID EventID => EventID.CapturePointFiveCap;
    }
    public class EventVictoryPointThreshold1 : Event<ArgsCapturePoint> //139
    { 
        public override EventID EventID => EventID.VictoryPointThreshold1;
    }
    public class EventVictoryPointThreshold2 : Event<ArgsCapturePoint> //140
    { 
        public override EventID EventID => EventID.VictoryPointThreshold2;
    }
    public class EventVictoryPointThreshold3 : Event<ArgsCapturePoint> //141
    { 
        public override EventID EventID => EventID.VictoryPointThreshold3;
    }
    public class EventVictoryPointThreshold4 : Event<ArgsCapturePoint> //142
    { 
        public override EventID EventID => EventID.VictoryPointThreshold4;
    }
    public class EventMinionKillVictoryThreshold1 : Event<ArgsBase> //143
    { 
        public override EventID EventID => EventID.MinionKillVictoryThreshold1;
    }
    public class EventMinionKillVictoryThreshold2 : Event<ArgsBase> //144
    { 
        public override EventID EventID => EventID.MinionKillVictoryThreshold2;
    }
    public class EventTurretKillVictoryThreshold1 : Event<ArgsBase> //145
    { 
        public override EventID EventID => EventID.TurretKillVictoryThreshold1;
    }
    public class EventTurretKillVictoryThreshold2 : Event<ArgsBase> //146
    { 
        public override EventID EventID => EventID.TurretKillVictoryThreshold2;
    }
    public class EventReplayFastForwardStart : Event<ArgsBase> //147
    { 
        public override EventID EventID => EventID.ReplayFastForwardStart;
    }
    public class EventReplayFastForwardEnd : Event<ArgsBase> //148
    { 
        public override EventID EventID => EventID.ReplayFastForwardEnd;
    }
    public class EventReplayOnKeyframeFinished : Event<ArgsBase> //149
    { 
        public override EventID EventID => EventID.ReplayOnKeyframeFinished;
    }
    public class EventReplayDestroyAllObjects : Event<ArgsBase> //150
    { 
        public override EventID EventID => EventID.ReplayDestroyAllObjects;
    }
    public class EventKillDragon : Event<ArgsMinionKill> //151
    { 
        public override EventID EventID => EventID.KillDragon;
    }
    public class EventKillDragonSpectator : Event<ArgsMinionKill> //152
    { 
        public override EventID EventID => EventID.KillDragonSpectator;
    }
    public class EventKillDragonSteal : Event<ArgsMinionKill> //153
    { 
        public override EventID EventID => EventID.KillDragonSteal;
    }
    public class EventKillWorm : Event<ArgsMinionKill> //154
    { 
        public override EventID EventID => EventID.KillWorm;
    }
    public class EventKillWormSpectator : Event<ArgsMinionKill> //155
    { 
        public override EventID EventID => EventID.KillWormSpectator;
    }
    public class EventKillWormSteal : Event<ArgsMinionKill> //156
    { 
        public override EventID EventID => EventID.KillWormSteal;
    }
    public class EventKillSpiderboss : Event<ArgsMinionKill> //157
    { 
        public override EventID EventID => EventID.KillSpiderboss;
    }
    public class EventKillSpiderbossSpectator : Event<ArgsMinionKill> //158
    { 
        public override EventID EventID => EventID.KillSpiderbossSpectator;
    }
    public class EventCaptureAltar : Event<ArgsCapturePoint> //159
    { 
        public override EventID EventID => EventID.CaptureAltar;
    }
    public class EventCaptureAltarSpectator : Event<ArgsCapturePoint> //160
    { 
        public override EventID EventID => EventID.CaptureAltarSpectator;
    }
    public class EventPlaceWard : Event<ArgsBase> //161
    { 
        public override EventID EventID => EventID.PlaceWard;
    }
    public class EventKillWard : Event<ArgsBase> //162
    { 
        public override EventID EventID => EventID.KillWard;
    }
    public class EventMinionAscended : Event<ArgsBase> //163
    { 
        public override EventID EventID => EventID.MinionAscended;
    }
    public class EventChampionAscended : Event<ArgsBase> //164
    { 
        public override EventID EventID => EventID.ChampionAscended;
    }
    public class EventClearAscended : Event<ArgsBase> //165
    { 
        public override EventID EventID => EventID.ClearAscended;
    }
    public class EventGameStat : Event<ArgsBase> //166
    { 
        public override EventID EventID => EventID.GameStat;
    }
}
