using System;
using System.Collections.Generic;

namespace LeaguePackets.Game.Events
{
    public class OnDelete : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnDelete;
    }
    public class OnSpawn : ArgsDie, IEvent
    {
        public EventID ID => EventID.OnSpawn;
    }
    public class OnDie : ArgsDie, IEvent
    {
        public EventID ID => EventID.OnDie;
    }
    public class OnKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKill;
    }
    public class OnChampionDie : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionDie;
    }
    public class OnChampionKillPre : ArgsChampionKillPre, IEvent
    {
        public EventID ID => EventID.OnChampionKillPre;
    }
    public class OnChampionKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionKill;
    }
    public class OnChampionKillBlind : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionKillBlind;
    }
    public class OnChampionKillPost : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionKillPost;
    }
    public class OnChampionSingleKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionSingleKill;
    }
    public class OnChampionDoubleKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionDoubleKill;
    }
    public class OnChampionTripleKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionTripleKill;
    }
    public class OnChampionQuadraKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionQuadraKill;
    }
    public class OnChampionPentaKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionPentaKill;
    }
    public class OnChampionUnrealKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnChampionUnrealKill;
    }
    public class OnFirstBlood : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnFirstBlood;
    }
    public class OnDamageTaken : ArgsDamage, IEvent
    {
        public EventID ID => EventID.OnDamageTaken;
    }
    public class OnDamageGiven : ArgsDamage, IEvent
    {
        public EventID ID => EventID.OnDamageGiven;
    }
    public class OnSpellCast1 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellCast1;
    }
    public class OnSpellCast2 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellCast2;
    }
    public class OnSpellCast3 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellCast3;
    }
    public class OnSpellCast4 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellCast4;
    }
    public class OnSpellAvatarCast1 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellAvatarCast1;
    }
    public class OnSpellAvatarCast2 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellAvatarCast2;
    }
    public class OnGoldSpent : ArgsGoldSpent, IEvent
    {
        public EventID ID => EventID.OnGoldSpent;
    }
    public class OnGoldEarned : ArgsGoldEarned, IEvent
    {
        public EventID ID => EventID.OnGoldEarned;
    }
    public class OnItemConsumeablePurchased : ArgsItemConsumedPurchased, IEvent
    {
        public EventID ID => EventID.OnItemConsumeablePurchased;
    }
    public class OnCriticalStrike : ArgsDamageCriticalStrike, IEvent
    {
        public EventID ID => EventID.OnCriticalStrike;
    }
    public class OnAce : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnAce;
    }
    public class OnReincarnate : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnReincarnate;
    }
    public class OnDampenerKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnDampenerKill;
    }
    public class OnDampenerDie : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnDampenerDie;
    }
    public class OnDampenerRespawnSoon : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnDampenerRespawnSoon;
    }
    public class OnDampenerRespawn : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnDampenerRespawn;
    }
    public class OnDampenerDamage : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnDampenerDamage;
    }
    public class OnTurretKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnTurretKill;
    }
    public class OnTurretDie : ArgsDie, IEvent
    {
        public EventID ID => EventID.OnTurretDie;
    }
    public class OnTurretDamage : ArgsDie, IEvent
    {
        public EventID ID => EventID.OnTurretDamage;
    }
    public class OnMinionKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnMinionKill;
    }
    public class OnMinionDenied : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnMinionDenied;
    }
    public class OnNeutralMinionKill : ArgsMinionKill, IEvent
    {
        public EventID ID => EventID.OnNeutralMinionKill;
    }
    public class OnSuperMonsterKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSuperMonsterKill;
    }
    public class OnHQKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnHQKill;
    }
    public class OnHQDie : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnHQDie;
    }
    public class OnHeal : ArgsHeal, IEvent
    {
        public EventID ID => EventID.OnHeal;
    }
    public class OnCastHeal : ArgsHeal, IEvent
    {
        public EventID ID => EventID.OnCastHeal;
    }
    public class OnBuff : ArgsBuff, IEvent
    {
        public EventID ID => EventID.OnBuff;
    }
    public class OnCrowdControlDealt : ArgsCC, IEvent
    {
        public EventID ID => EventID.OnCrowdControlDealt;
    }
    public class OnKillingSpree : ArgsKillingSpree, IEvent
    {
        public EventID ID => EventID.OnKillingSpree;
    }
    public class OnKillingSpreeSet1 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKillingSpreeSet1;
    }
    public class OnKillingSpreeSet2 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKillingSpreeSet2;
    }
    public class OnKillingSpreeSet3 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKillingSpreeSet3;
    }
    public class OnKillingSpreeSet4 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKillingSpreeSet4;
    }
    public class OnKillingSpreeSet5 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKillingSpreeSet5;
    }
    public class OnKillingSpreeSet6 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKillingSpreeSet6;
    }
    public class OnKilledUnitOnKillingSpree : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpree;
    }
    public class OnKilledUnitOnKillingSpreeSet1 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet1;
    }
    public class OnKilledUnitOnKillingSpreeSet2 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet2;
    }
    public class OnKilledUnitOnKillingSpreeSet3 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet3;
    }
    public class OnKilledUnitOnKillingSpreeSet4 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet4;
    }
    public class OnKilledUnitOnKillingSpreeSet5 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet5;
    }
    public class OnKilledUnitOnKillingSpreeSet6 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeSet6;
    }
    public class OnKilledUnitOnKillingSpreeDoubleKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeDoubleKill;
    }
    public class OnKilledUnitOnKillingSpreeTripleKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeTripleKill;
    }
    public class OnKilledUnitOnKillingSpreeQuadraKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeQuadraKill;
    }
    public class OnKilledUnitOnKillingSpreePentaKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreePentaKill;
    }
    public class OnKilledUnitOnKillingSpreeUnrealKill : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKilledUnitOnKillingSpreeUnrealKill;
    }
    public class OnDeathAssist : ArgsAssist, IEvent
    {
        public EventID ID => EventID.OnDeathAssist;
    }
    public class OnQuit : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnQuit;
    }
    public class OnLeave : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnLeave;
    }
    public class OnReconnect : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnReconnect;
    }
    public class OnGameStart : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnGameStart;
    }
    public class OnPing : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnPing;
    }
    public class OnPingPlayer : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnPingPlayer;
    }
    public class OnPingBuilding : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnPingBuilding;
    }
    public class OnPingOther : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnPingOther;
    }
    public class OnEndGame : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEndGame;
    }
    public class OnSpellLevelup1 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellLevelup1;
    }
    public class OnSpellLevelup2 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellLevelup2;
    }
    public class OnSpellLevelup3 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellLevelup3;
    }
    public class OnSpellLevelup4 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSpellLevelup4;
    }
    public class OnItemPurchased : ArgsItemConsumedPurchased, IEvent
    {
        public EventID ID => EventID.OnItemPurchased;
    }
    public class OnItemSold : ArgsItemSoldOrRemoved, IEvent
    {
        public EventID ID => EventID.OnItemSold;
    }
    public class OnItemRemoved : ArgsItemSoldOrRemoved, IEvent
    {
        public EventID ID => EventID.OnItemRemoved;
    }
    public class OnItemCallout : ArgsItemCallout, IEvent
    {
        public EventID ID => EventID.OnItemCallout;
    }
    public class OnItemChange : ArgsItemChange, IEvent
    {
        public EventID ID => EventID.OnItemChange;
    }
    public class OnUndoEnabledChange : ArgsUndoEnabledChange, IEvent
    {
        public EventID ID => EventID.OnUndoEnabledChange;
    }
    public class OnSurrenderVoteStart : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSurrenderVoteStart;
    }
    public class OnSurrenderVote : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSurrenderVote;
    }
    public class OnSurrenderVoteAlready : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSurrenderVoteAlready;
    }
    public class OnSurrenderFailedVotes : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSurrenderFailedVotes;
    }
    public class OnSurrenderTooEarly : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSurrenderTooEarly;
    }
    public class OnSurrenderAgreed : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSurrenderAgreed;
    }
    public class OnSurrenderSpam : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnSurrenderSpam;
    }
    public class OnEqualizeVoteStart : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeVoteStart;
    }
    public class OnEqualizeVote : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeVote;
    }
    public class OnEqualizeVoteAlready : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeVoteAlready;
    }
    public class OnEqualizeFailedVotes : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeFailedVotes;
    }
    public class OnEqualizeTooEarly : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeTooEarly;
    }
    public class OnEqualizeNotEnoughGold : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeNotEnoughGold;
    }
    public class OnEqualizeNotEnoughLevels : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeNotEnoughLevels;
    }
    public class OnEqualizeAgreed : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeAgreed;
    }
    public class OnEqualizeSpam : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnEqualizeSpam;
    }
    public class OnPause : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnPause;
    }
    public class OnPauseResume : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnPauseResume;
    }
    public class OnMinionsSpawn : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnMinionsSpawn;
    }
    public class OnStartGameMessage1 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnStartGameMessage1;
    }
    public class OnStartGameMessage2 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnStartGameMessage2;
    }
    public class OnStartGameMessage3 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnStartGameMessage3;
    }
    public class OnStartGameMessage4 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnStartGameMessage4;
    }
    public class OnStartGameMessage5 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnStartGameMessage5;
    }
    public class OnAlert : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnAlert;
    }
    public class OnScoreboardOpen : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnScoreboardOpen;
    }
    public class OnAudioEventFinished : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnAudioEventFinished;
    }
    public class OnNexusCrystalStart : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnNexusCrystalStart;
    }
    public class OnCapturePointNeutralized_A : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointNeutralized_A;
    }
    public class OnCapturePointNeutralized_B : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointNeutralized_B;
    }
    public class OnCapturePointNeutralized_C : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointNeutralized_C;
    }
    public class OnCapturePointNeutralized_D : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointNeutralized_D;
    }
    public class OnCapturePointNeutralized_E : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointNeutralized_E;
    }
    public class OnCapturePointCaptured_A : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointCaptured_A;
    }
    public class OnCapturePointCaptured_B : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointCaptured_B;
    }
    public class OnCapturePointCaptured_C : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointCaptured_C;
    }
    public class OnCapturePointCaptured_D : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointCaptured_D;
    }
    public class OnCapturePointCaptured_E : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointCaptured_E;
    }
    public class OnCapturePointFiveCap : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnCapturePointFiveCap;
    }
    public class OnVictoryPointThreshold1 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnVictoryPointThreshold1;
    }
    public class OnVictoryPointThreshold2 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnVictoryPointThreshold2;
    }
    public class OnVictoryPointThreshold3 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnVictoryPointThreshold3;
    }
    public class OnVictoryPointThreshold4 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnVictoryPointThreshold4;
    }
    public class OnMinionKillVictoryThreshold1 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnMinionKillVictoryThreshold1;
    }
    public class OnMinionKillVictoryThreshold2 : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnMinionKillVictoryThreshold2;
    }
    public class OnReplayFastForwardStart : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnReplayFastForwardStart;
    }
    public class OnReplayFastForwardEnd : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnReplayFastForwardEnd;
    }
    public class OnReplayOnKeyframeFinished : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnReplayOnKeyframeFinished;
    }
    public class OnKillDragon : ArgsMinionKill, IEvent
    {
        public EventID ID => EventID.OnKillDragon;
    }
    public class OnKillDragon_Spectator : ArgsMinionKill, IEvent
    {
        public EventID ID => EventID.OnKillDragon_Spectator;
    }
    public class OnKillWorm : ArgsMinionKill, IEvent
    {
        public EventID ID => EventID.OnKillWorm;
    }
    public class OnKillWorm_Spectator : ArgsMinionKill, IEvent
    {
        public EventID ID => EventID.OnKillWorm_Spectator;
    }
    public class OnKillSpiderBoss : ArgsMinionKill, IEvent
    {
        public EventID ID => EventID.OnKillSpiderBoss;
    }
    public class OnKillSpiderBoss_Spectator : ArgsMinionKill, IEvent
    {
        public EventID ID => EventID.OnKillSpiderBoss_Spectator;
    }
    public class OnCaptureAltar : ArgsCapturePoint, IEvent
    {
        public EventID ID => EventID.OnCaptureAltar;
    }
    public class OnCaptureAltar_Spectator : ArgsCapturePoint, IEvent
    {
        public EventID ID => EventID.OnCaptureAltar_Spectator;
    }
    public class OnPlaceWard : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnPlaceWard;
    }
    public class OnKillWard : ArgsBase, IEvent
    {
        public EventID ID => EventID.OnKillWard;
    }
}
