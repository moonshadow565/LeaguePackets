using System;
using LeaguePackets.Common;
using System.Collections.Generic;
using LeaguePackets.CommonData.Events;
namespace LeaguePackets.CommonData
{
    public abstract partial class Event
    {
        private static readonly Dictionary<EventID, Func<PacketReader, Event>> _lookup
            = new Dictionary<EventID, Func<PacketReader, Event>>
            {
                {
                    EventID.Delete,
                    (r) => new EventDelete()
                },
                {
                    EventID.Spawn,
                    (r) => new EventSpawn()
                },
                {
                    EventID.Die,
                    (r) => new EventDie()
                },
                {
                    EventID.Kill,
                    (r) => new EventKill()
                },
                {
                    EventID.ChampionDie,
                    (r) => new EventChampionDie()
                },
                {
                    EventID.ChampionKillPre,
                    (r) => new EventChampionKillPre()
                },
                {
                    EventID.ChampionKill,
                    (r) => new EventChampionKill()
                },
                {
                    EventID.ChampionKillPost,
                    (r) => new EventChampionKillPost()
                },
                {
                    EventID.ChampionSinglekill,
                    (r) => new EventChampionSinglekill()
                },
                {
                    EventID.ChampionDoublekill,
                    (r) => new EventChampionDoublekill()
                },
                {
                    EventID.ChampionTriplekill,
                    (r) => new EventChampionTriplekill()
                },
                {
                    EventID.ChampionQuadrakill,
                    (r) => new EventChampionQuadrakill()
                },
                {
                    EventID.ChampionPentakill,
                    (r) => new EventChampionPentakill()
                },
                {
                    EventID.ChampionUnrealkill,
                    (r) => new EventChampionUnrealkill()
                },
                {
                    EventID.Firstblood,
                    (r) => new EventFirstblood()
                },
                {
                    EventID.DamageTaken,
                    (r) => new EventDamageTaken()
                },
                {
                    EventID.DamageGiven,
                    (r) => new EventDamageGiven()
                },
                {
                    EventID.SpellCast1,
                    (r) => new EventSpellCast1()
                },
                {
                    EventID.SpellCast2,
                    (r) => new EventSpellCast2()
                },
                {
                    EventID.SpellCast3,
                    (r) => new EventSpellCast3()
                },
                {
                    EventID.SpellCast4,
                    (r) => new EventSpellCast4()
                },
                {
                    EventID.SpellAvatarCast1,
                    (r) => new EventSpellAvatarCast1()
                },
                {
                    EventID.SpellAvatarCast2,
                    (r) => new EventSpellAvatarCast2()
                },
                {
                    EventID.GoldSpent,
                    (r) => new EventGoldSpent()
                },
                {
                    EventID.GoldEarned,
                    (r) => new EventGoldEarned()
                },
                {
                    EventID.ItemConsumeablePurchased,
                    (r) => new EventItemConsumeablePurchased()
                },
                {
                    EventID.CriticalStrike,
                    (r) => new EventCriticalStrike()
                },
                {
                    EventID.Ace,
                    (r) => new EventAce()
                },
                {
                    EventID.Reincarnate,
                    (r) => new EventReincarnate()
                },
                {
                    EventID.ChangeChampion,
                    (r) => new EventChangeChampion()
                },
                {
                    EventID.DampenerKill,
                    (r) => new EventDampenerKill()
                },
                {
                    EventID.DampenerDie,
                    (r) => new EventDampenerDie()
                },
                {
                    EventID.DampenerRespawnSoon,
                    (r) => new EventDampenerRespawnSoon()
                },
                {
                    EventID.DampenerRespawn,
                    (r) => new EventDampenerRespawn()
                },
                {
                    EventID.DampenerDamage,
                    (r) => new EventDampenerDamage()
                },
                {
                    EventID.TurretKill,
                    (r) => new EventTurretKill()
                },
                {
                    EventID.TurretDie,
                    (r) => new EventTurretDie()
                },
                {
                    EventID.TurretDamage,
                    (r) => new EventTurretDamage()
                },
                {
                    EventID.MinionKill,
                    (r) => new EventMinionKill()
                },
                {
                    EventID.MinionDenied,
                    (r) => new EventMinionDenied()
                },
                {
                    EventID.NeutralMinionKill,
                    (r) => new EventNeutralMinionKill()
                },
                {
                    EventID.SuperMonsterKill,
                    (r) => new EventSuperMonsterKill()
                },
                {
                    EventID.AcquireRedBuffFromNeutral,
                    (r) => new EventAcquireRedBuffFromNeutral()
                },
                {
                    EventID.AcquireBlueBuffFromNeutral,
                    (r) => new EventAcquireBlueBuffFromNeutral()
                },
                {
                    EventID.HqDie,
                    (r) => new EventHqDie()
                },
                {
                    EventID.HqKill,
                    (r) => new EventHqKill()
                },
                {
                    EventID.Heal,
                    (r) => new EventHeal()
                },
                {
                    EventID.CastHeal,
                    (r) => new EventCastHeal()
                },
                {
                    EventID.Buff,
                    (r) => new EventBuff()
                },
                {
                    EventID.CrowdControlDealt,
                    (r) => new EventCrowdControlDealt()
                },
                {
                    EventID.KillingSpree,
                    (r) => new EventKillingSpree()
                },
                {
                    EventID.KillingSpreeSet1,
                    (r) => new EventKillingSpreeSet1()
                },
                {
                    EventID.KillingSpreeSet2,
                    (r) => new EventKillingSpreeSet2()
                },
                {
                    EventID.KillingSpreeSet3,
                    (r) => new EventKillingSpreeSet3()
                },
                {
                    EventID.KillingSpreeSet4,
                    (r) => new EventKillingSpreeSet4()
                },
                {
                    EventID.KillingSpreeSet5,
                    (r) => new EventKillingSpreeSet5()
                },
                {
                    EventID.KillingSpreeSet6,
                    (r) => new EventKillingSpreeSet6()
                },
                {
                    EventID.KilledUnitOnKillingSpree,
                    (r) => new EventKilledUnitOnKillingSpree()
                },
                {
                    EventID.KilledUnitOnKillingSpreeSet1,
                    (r) => new EventKilledUnitOnKillingSpreeSet1()
                },
                {
                    EventID.KilledUnitOnKillingSpreeSet2,
                    (r) => new EventKilledUnitOnKillingSpreeSet2()
                },
                {
                    EventID.KilledUnitOnKillingSpreeSet3,
                    (r) => new EventKilledUnitOnKillingSpreeSet3()
                },
                {
                    EventID.KilledUnitOnKillingSpreeSet4,
                    (r) => new EventKilledUnitOnKillingSpreeSet4()
                },
                {
                    EventID.KilledUnitOnKillingSpreeSet5,
                    (r) => new EventKilledUnitOnKillingSpreeSet5()
                },
                {
                    EventID.KilledUnitOnKillingSpreeSet6,
                    (r) => new EventKilledUnitOnKillingSpreeSet6()
                },
                {
                    EventID.KilledUnitOnKillingSpreeDoublekill,
                    (r) => new EventKilledUnitOnKillingSpreeDoublekill()
                },
                {
                    EventID.KilledUnitOnKillingSpreeTriplekill,
                    (r) => new EventKilledUnitOnKillingSpreeTriplekill()
                },
                {
                    EventID.KilledUnitOnKillingSpreeQuadrakill,
                    (r) => new EventKilledUnitOnKillingSpreeQuadrakill()
                },
                {
                    EventID.KilledUnitOnKillingSpreePentakill,
                    (r) => new EventKilledUnitOnKillingSpreePentakill()
                },
                {
                    EventID.KilledUnitOnKillingSpreeUnrealkill,
                    (r) => new EventKilledUnitOnKillingSpreeUnrealkill()
                },
                {
                    EventID.DeathAssist,
                    (r) => new EventDeathAssist()
                },
                {
                    EventID.Quit,
                    (r) => new EventQuit()
                },
                {
                    EventID.Leave,
                    (r) => new EventLeave()
                },
                {
                    EventID.Reconnect,
                    (r) => new EventReconnect()
                },
                {
                    EventID.GameEnter,
                    (r) => new EventGameEnter()
                },
                {
                    EventID.AssistingSpreeSet1,
                    (r) => new EventAssistingSpreeSet1()
                },
                {
                    EventID.AssistingSpreeSet2,
                    (r) => new EventAssistingSpreeSet2()
                },
                {
                    EventID.TripleAssist,
                    (r) => new EventTripleAssist()
                },
                {
                    EventID.PentaAssist,
                    (r) => new EventPentaAssist()
                },
                {
                    EventID.Ping,
                    (r) => new EventPing()
                },
                {
                    EventID.PingPlayer,
                    (r) => new EventPingPlayer()
                },
                {
                    EventID.PingBuilding,
                    (r) => new EventPingBuilding()
                },
                {
                    EventID.PingOther,
                    (r) => new EventPingOther()
                },
                {
                    EventID.EndGame,
                    (r) => new EventEndGame()
                },
                {
                    EventID.SpellLevelup1,
                    (r) => new EventSpellLevelup1()
                },
                {
                    EventID.SpellLevelup2,
                    (r) => new EventSpellLevelup2()
                },
                {
                    EventID.SpellLevelup3,
                    (r) => new EventSpellLevelup3()
                },
                {
                    EventID.SpellLevelup4,
                    (r) => new EventSpellLevelup4()
                },
                {
                    EventID.SpellEvolve1,
                    (r) => new EventSpellEvolve1()
                },
                {
                    EventID.SpellEvolve2,
                    (r) => new EventSpellEvolve2()
                },
                {
                    EventID.SpellEvolve3,
                    (r) => new EventSpellEvolve3()
                },
                {
                    EventID.SpellEvolve4,
                    (r) => new EventSpellEvolve4()
                },
                {
                    EventID.ItemPurchased,
                    (r) => new EventItemPurchased()
                },
                {
                    EventID.ItemSold,
                    (r) => new EventItemSold()
                },
                {
                    EventID.ItemRemoved,
                    (r) => new EventItemRemoved()
                },
                {
                    EventID.ItemUndo,
                    (r) => new EventItemUndo()
                },
                {
                    EventID.ItemCallout,
                    (r) => new EventItemCallout()
                },
                {
                    EventID.ItemClientChange,
                    (r) => new EventItemClientChange()
                },
                {
                    EventID.UndoEnabledChange,
                    (r) => new EventUndoEnabledChange()
                },
                {
                    EventID.ShopItemSubstitutionChange,
                    (r) => new EventShopItemSubstitutionChange()
                },
                {
                    EventID.SurrenderVoteStart,
                    (r) => new EventSurrenderVoteStart()
                },
                {
                    EventID.SurrenderVote,
                    (r) => new EventSurrenderVote()
                },
                {
                    EventID.SurrenderVoteAlready,
                    (r) => new EventSurrenderVoteAlready()
                },
                {
                    EventID.SurrenderFailedVotes,
                    (r) => new EventSurrenderFailedVotes()
                },
                {
                    EventID.SurrenderFailedTooEarly,
                    (r) => new EventSurrenderFailedTooEarly()
                },
                {
                    EventID.SurrenderAgreed,
                    (r) => new EventSurrenderAgreed()
                },
                {
                    EventID.SurrenderSpam,
                    (r) => new EventSurrenderSpam()
                },
                {
                    EventID.EarlySurrenderAllowed,
                    (r) => new EventEarlySurrenderAllowed()
                },
                {
                    EventID.EqualizeVoteStart,
                    (r) => new EventEqualizeVoteStart()
                },
                {
                    EventID.EqualizeVote,
                    (r) => new EventEqualizeVote()
                },
                {
                    EventID.EqualizeVoteAlready,
                    (r) => new EventEqualizeVoteAlready()
                },
                {
                    EventID.EqualizeFailedVotes,
                    (r) => new EventEqualizeFailedVotes()
                },
                {
                    EventID.EqualizeFailedTooEarly,
                    (r) => new EventEqualizeFailedTooEarly()
                },
                {
                    EventID.EqualizeFailedNoGoldLead,
                    (r) => new EventEqualizeFailedNoGoldLead()
                },
                {
                    EventID.EqualizeFailedNoLevelLead,
                    (r) => new EventEqualizeFailedNoLevelLead()
                },
                {
                    EventID.EqualizeAgreed,
                    (r) => new EventEqualizeAgreed()
                },
                {
                    EventID.EqualizeSpam,
                    (r) => new EventEqualizeSpam()
                },
                {
                    EventID.Pause,
                    (r) => new EventPause()
                },
                {
                    EventID.PauseResume,
                    (r) => new EventPauseResume()
                },
                {
                    EventID.MinionsSpawn,
                    (r) => new EventMinionsSpawn()
                },
                {
                    EventID.StartGameMessage1,
                    (r) => new EventStartGameMessage1()
                },
                {
                    EventID.StartGameMessage2,
                    (r) => new EventStartGameMessage2()
                },
                {
                    EventID.StartGameMessage3,
                    (r) => new EventStartGameMessage3()
                },
                {
                    EventID.StartGameMessage4,
                    (r) => new EventStartGameMessage4()
                },
                {
                    EventID.StartGameMessage5,
                    (r) => new EventStartGameMessage5()
                },
                {
                    EventID.Alert,
                    (r) => new EventAlert()
                },
                {
                    EventID.ScoreboardOpen,
                    (r) => new EventScoreboardOpen()
                },
                {
                    EventID.AudioEventFinished,
                    (r) => new EventAudioEventFinished()
                },
                {
                    EventID.NexusCrystalStart,
                    (r) => new EventNexusCrystalStart()
                },
                {
                    EventID.CapturePointNeutralizedA,
                    (r) => new EventCapturePointNeutralizedA()
                },
                {
                    EventID.CapturePointNeutralizedB,
                    (r) => new EventCapturePointNeutralizedB()
                },
                {
                    EventID.CapturePointNeutralizedC,
                    (r) => new EventCapturePointNeutralizedC()
                },
                {
                    EventID.CapturePointNeutralizedD,
                    (r) => new EventCapturePointNeutralizedD()
                },
                {
                    EventID.CapturePointNeutralizedE,
                    (r) => new EventCapturePointNeutralizedE()
                },
                {
                    EventID.CapturePointCapturedA,
                    (r) => new EventCapturePointCapturedA()
                },
                {
                    EventID.CapturePointCapturedB,
                    (r) => new EventCapturePointCapturedB()
                },
                {
                    EventID.CapturePointCapturedC,
                    (r) => new EventCapturePointCapturedC()
                },
                {
                    EventID.CapturePointCapturedD,
                    (r) => new EventCapturePointCapturedD()
                },
                {
                    EventID.CapturePointCapturedE,
                    (r) => new EventCapturePointCapturedE()
                },
                {
                    EventID.CapturePointFiveCap,
                    (r) => new EventCapturePointFiveCap()
                },
                {
                    EventID.VictoryPointThreshold1,
                    (r) => new EventVictoryPointThreshold1()
                },
                {
                    EventID.VictoryPointThreshold2,
                    (r) => new EventVictoryPointThreshold2()
                },
                {
                    EventID.VictoryPointThreshold3,
                    (r) => new EventVictoryPointThreshold3()
                },
                {
                    EventID.VictoryPointThreshold4,
                    (r) => new EventVictoryPointThreshold4()
                },
                {
                    EventID.MinionKillVictoryThreshold1,
                    (r) => new EventMinionKillVictoryThreshold1()
                },
                {
                    EventID.MinionKillVictoryThreshold2,
                    (r) => new EventMinionKillVictoryThreshold2()
                },
                {
                    EventID.TurretKillVictoryThreshold1,
                    (r) => new EventTurretKillVictoryThreshold1()
                },
                {
                    EventID.TurretKillVictoryThreshold2,
                    (r) => new EventTurretKillVictoryThreshold2()
                },
                {
                    EventID.ReplayFastForwardStart,
                    (r) => new EventReplayFastForwardStart()
                },
                {
                    EventID.ReplayFastForwardEnd,
                    (r) => new EventReplayFastForwardEnd()
                },
                {
                    EventID.ReplayOnKeyframeFinished,
                    (r) => new EventReplayOnKeyframeFinished()
                },
                {
                    EventID.ReplayDestroyAllObjects,
                    (r) => new EventReplayDestroyAllObjects()
                },
                {
                    EventID.KillDragon,
                    (r) => new EventKillDragon()
                },
                {
                    EventID.KillDragonSpectator,
                    (r) => new EventKillDragonSpectator()
                },
                {
                    EventID.KillDragonSteal,
                    (r) => new EventKillDragonSteal()
                },
                {
                    EventID.KillWorm,
                    (r) => new EventKillWorm()
                },
                {
                    EventID.KillWormSpectator,
                    (r) => new EventKillWormSpectator()
                },
                {
                    EventID.KillWormSteal,
                    (r) => new EventKillWormSteal()
                },
                {
                    EventID.KillSpiderboss,
                    (r) => new EventKillSpiderboss()
                },
                {
                    EventID.KillSpiderbossSpectator,
                    (r) => new EventKillSpiderbossSpectator()
                },
                {
                    EventID.CaptureAltar,
                    (r) => new EventCaptureAltar()
                },
                {
                    EventID.CaptureAltarSpectator,
                    (r) => new EventCaptureAltarSpectator()
                },
                {
                    EventID.PlaceWard,
                    (r) => new EventPlaceWard()
                },
                {
                    EventID.KillWard,
                    (r) => new EventKillWard()
                },
                {
                    EventID.MinionAscended,
                    (r) => new EventMinionAscended()
                },
                {
                    EventID.ChampionAscended,
                    (r) => new EventChampionAscended()
                },
                {
                    EventID.ClearAscended,
                    (r) => new EventClearAscended()
                },
                {
                    EventID.GameStat,
                    (r) => new EventGameStat()
                },
            };
    }
}
