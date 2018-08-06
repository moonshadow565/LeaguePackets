using LeaguePackets.GamePackets;
using LeaguePackets.Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public abstract partial class GamePacket
    {
        private static readonly Dictionary<GamePacketID, Func<PacketReader, NetID, GamePacket>> _lookup
        = new Dictionary<GamePacketID, Func<PacketReader, NetID, GamePacket>>
        {
            {
                GamePacketID.Dummy,
                (r,n) => Dummy.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_HierarchicalProfilerUpdate,
                (r,n) => SPM_HierarchicalProfilerUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_DisplayLocalizedTutorialChatText,
                (r,n) => S2C_DisplayLocalizedTutorialChatText.CreateBody(r,n)
            },
            {
                GamePacketID.Barrack_SpawnUnit,
                (r,n) => Barrack_SpawnUnit.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SwitchNexusesToOnIdleParticles,
                (r,n) => S2C_SwitchNexusesToOnIdleParticles.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_TutorialAudioEventFinished,
                (r,n) => C2S_TutorialAudioEventFinished.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetCircularMovementRestriction,
                (r,n) => S2C_SetCircularMovementRestriction.CreateBody(r,n)
            },
            {
                GamePacketID.UpdateGoldRedirectTarget,
                (r,n) => UpdateGoldRedirectTarget.CreateBody(r,n)
            },
            {
                GamePacketID.SynchSimTimeC2S,
                (r,n) => SynchSimTimeC2S.CreateBody(r,n)
            },
            {
                GamePacketID.RemoveItemReq,
                (r,n) => RemoveItemReq.CreateBody(r,n)
            },
            {
                GamePacketID.ResumePacket,
                (r,n) => ResumePacket.CreateBody(r,n)
            },
            {
                GamePacketID.RemoveItemAns,
                (r,n) => RemoveItemAns.CreateBody(r,n)
            },
            {
                GamePacketID.Basic_Attack,
                (r,n) => Basic_Attack.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ReplaceObjectiveText,
                (r,n) => S2C_ReplaceObjectiveText.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CloseShop,
                (r,n) => S2C_CloseShop.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_Reconnect,
                (r,n) => S2C_Reconnect.CreateBody(r,n)
            },
            {
                GamePacketID.UnitAddEXP,
                (r,n) => UnitAddEXP.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_EndSpawn,
                (r,n) => S2C_EndSpawn.CreateBody(r,n)
            },
            {
                GamePacketID.SetFrequency,
                (r,n) => SetFrequency.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_BotAI,
                (r,n) => S2C_BotAI.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_QueryStatusReq,
                (r,n) => C2S_QueryStatusReq.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_UpgradeSpellAns,
                (r,n) => NPC_UpgradeSpellAns.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_Ping_Load_Info,
                (r,n) => C2S_Ping_Load_Info.CreateBody(r,n)
            },
            {
                GamePacketID.ChangeSlotSpellData,
                (r,n) => ChangeSlotSpellData.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_MessageToClient,
                (r,n) => NPC_MessageToClient.CreateBody(r,n)
            },
            {
                GamePacketID.DisplayFloatingText,
                (r,n) => DisplayFloatingText.CreateBody(r,n)
            },
            {
                GamePacketID.Basic_Attack_Pos,
                (r,n) => Basic_Attack_Pos.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_ForceDead,
                (r,n) => NPC_ForceDead.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffUpdateCount,
                (r,n) => NPC_BuffUpdateCount.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_WriteNavFlags_Acc,
                (r,n) => C2S_WriteNavFlags_Acc.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffReplaceGroup,
                (r,n) => NPC_BuffReplaceGroup.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_SetAutocast,
                (r,n) => NPC_SetAutocast.CreateBody(r,n)
            },
            {
                GamePacketID.SwapItemReq,
                (r,n) => SwapItemReq.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_Die_EventHistory,
                (r,n) => NPC_Die_EventHistory.CreateBody(r,n)
            },
            {
                GamePacketID.UnitAddGold,
                (r,n) => UnitAddGold.CreateBody(r,n)
            },
            {
                GamePacketID.AddRegion,
                (r,n) => AddRegion.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_MoveRegion,
                (r,n) => S2C_MoveRegion.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_MoveCameraToPoint,
                (r,n) => S2C_MoveCameraToPoint.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_LineMissileHitList,
                (r,n) => S2C_LineMissileHitList.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_MuteVolumeCategory,
                (r,n) => S2C_MuteVolumeCategory.CreateBody(r,n)
            },
            {
                GamePacketID.ServerTick,
                (r,n) => ServerTick.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_StopAnimation,
                (r,n) => S2C_StopAnimation.CreateBody(r,n)
            },
            {
                GamePacketID.AvatarInfo_Server,
                (r,n) => AvatarInfo_Server.CreateBody(r,n)
            },
            {
                GamePacketID.DampenerSwitchStates,
                (r,n) => DampenerSwitchStates.CreateBody(r,n)
            },
            {
                GamePacketID.World_SendCamera_Server_Acknologment,
                (r,n) => World_SendCamera_Server_Acknologment.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ModifyDebugCircleRadius,
                (r,n) => S2C_ModifyDebugCircleRadius.CreateBody(r,n)
            },
            {
                GamePacketID.World_SendCamera_Server,
                (r,n) => World_SendCamera_Server.CreateBody(r,n)
            },
            {
                GamePacketID.HeroReincarnateAlive,
                (r,n) => HeroReincarnateAlive.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffReplace,
                (r,n) => NPC_BuffReplace.CreateBody(r,n)
            },
            {
                GamePacketID.Pause,
                (r,n) => Pause.CreateBody(r,n)
            },
            {
                GamePacketID.SetFadeOut_Pop,
                (r,n) => SetFadeOut_Pop.CreateBody(r,n)
            },
            {
                GamePacketID.RemoveRegion,
                (r,n) => RemoveRegion.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_InstantStop_Attack,
                (r,n) => NPC_InstantStop_Attack.CreateBody(r,n)
            },
            {
                GamePacketID.OnLeaveLocalVisiblityClient,
                (r,n) => OnLeaveLocalVisiblityClient.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ShowObjectiveText,
                (r,n) => S2C_ShowObjectiveText.CreateBody(r,n)
            },
            {
                GamePacketID.CHAR_SpawnPet,
                (r,n) => CHAR_SpawnPet.CreateBody(r,n)
            },
            {
                GamePacketID.FX_Kill,
                (r,n) => FX_Kill.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_UpgradeSpellReq,
                (r,n) => NPC_UpgradeSpellReq.CreateBody(r,n)
            },
            {
                GamePacketID.UseObjectC2S,
                (r,n) => UseObjectC2S.CreateBody(r,n)
            },
            {
                GamePacketID.MissileReplication,
                (r,n) => MissileReplication.CreateBody(r,n)
            },
            {
                GamePacketID.MovementDriverReplication,
                (r,n) => MovementDriverReplication.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HighlightHUDElement,
                (r,n) => S2C_HighlightHUDElement.CreateBody(r,n)
            },
            {
                GamePacketID.SwapItemAns,
                (r,n) => SwapItemAns.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_LevelUp,
                (r,n) => NPC_LevelUp.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_MapPing,
                (r,n) => S2C_MapPing.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_WriteNavFlags,
                (r,n) => S2C_WriteNavFlags.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PlayEmote,
                (r,n) => S2C_PlayEmote.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PlaySound,
                (r,n) => S2C_PlaySound.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PlayVOCommand,
                (r,n) => S2C_PlayVOCommand.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_OnEventWorld,
                (r,n) => S2C_OnEventWorld.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HeroStats,
                (r,n) => S2C_HeroStats.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_UpdateGameOptions,
                (r,n) => C2S_UpdateGameOptions.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_PlayEmote,
                (r,n) => C2S_PlayEmote.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_PlayVOCommand,
                (r,n) => C2S_PlayVOCommand.CreateBody(r,n)
            },
            {
                GamePacketID.HeroReincarnate,
                (r,n) => HeroReincarnate.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_OnScoreBoardOpened,
                (r,n) => C2S_OnScoreBoardOpened.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CreateHero,
                (r,n) => S2C_CreateHero.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_AddMemoryListener,
                (r,n) => SPM_AddMemoryListener.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_HierarchicalMemoryUpdate,
                (r,n) => SPM_HierarchicalMemoryUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ToggleUIHighlight,
                (r,n) => S2C_ToggleUIHighlight.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_FaceDirection,
                (r,n) => S2C_FaceDirection.CreateBody(r,n)
            },
            {
                GamePacketID.OnLeaveVisiblityClient,
                (r,n) => OnLeaveVisiblityClient.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_ClientReady,
                (r,n) => C2S_ClientReady.CreateBody(r,n)
            },
            {
                GamePacketID.SetItem,
                (r,n) => SetItem.CreateBody(r,n)
            },
            {
                GamePacketID.SynchVersionS2C,
                (r,n) => SynchVersionS2C.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HandleTipUpdate,
                (r,n) => S2C_HandleTipUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_StatsUpdateReq,
                (r,n) => C2S_StatsUpdateReq.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_MapPing,
                (r,n) => C2S_MapPing.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_RemoveDebugObject,
                (r,n) => S2C_RemoveDebugObject.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CreateUnitHighlight,
                (r,n) => S2C_CreateUnitHighlight.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_DestroyClientMissile,
                (r,n) => S2C_DestroyClientMissile.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetSpellLevel,
                (r,n) => S2C_SetSpellLevel.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_StartGame,
                (r,n) => S2C_StartGame.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_OnShopOpened,
                (r,n) => C2S_OnShopOpened.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_Hero_Die,
                (r,n) => NPC_Hero_Die.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_FadeOutMainSFX,
                (r,n) => S2C_FadeOutMainSFX.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PlayThemeMusic,
                (r,n) => S2C_PlayThemeMusic.CreateBody(r,n)
            },
            {
                GamePacketID.WaypointGroup,
                (r,n) => WaypointGroup.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_StartSpawn,
                (r,n) => S2C_StartSpawn.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CreateNeutral,
                (r,n) => S2C_CreateNeutral.CreateBody(r,n)
            },
            {
                GamePacketID.WaypointGroupWithSpeed,
                (r,n) => WaypointGroupWithSpeed.CreateBody(r,n)
            },
            {
                GamePacketID.UnitApplyDamage,
                (r,n) => UnitApplyDamage.CreateBody(r,n)
            },
            {
                GamePacketID.ModifyShield,
                (r,n) => ModifyShield.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PopCharacterData,
                (r,n) => S2C_PopCharacterData.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffAddGroup,
                (r,n) => NPC_BuffAddGroup.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_AI_TargetSelection,
                (r,n) => S2C_AI_TargetSelection.CreateBody(r,n)
            },
            {
                GamePacketID.AI_TargetS2C,
                (r,n) => AI_TargetS2C.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetAnimStates,
                (r,n) => S2C_SetAnimStates.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ChainMissileSync,
                (r,n) => S2C_ChainMissileSync.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_OnTipEvent,
                (r,n) => C2S_OnTipEvent.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ForceCreateMissile,
                (r,n) => S2C_ForceCreateMissile.CreateBody(r,n)
            },
            {
                GamePacketID.BuyItemAns,
                (r,n) => BuyItemAns.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetSpellData,
                (r,n) => S2C_SetSpellData.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PauseAnimation,
                (r,n) => S2C_PauseAnimation.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_IssueOrderReq,
                (r,n) => NPC_IssueOrderReq.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CameraBehavior,
                (r,n) => S2C_CameraBehavior.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_AnimatedBuildingSetCurrentSkin,
                (r,n) => S2C_AnimatedBuildingSetCurrentSkin.CreateBody(r,n)
            },
            {
                GamePacketID.Connected,
                (r,n) => Connected.CreateBody(r,n)
            },
            {
                GamePacketID.SyncSimTimeFinalS2C,
                (r,n) => SyncSimTimeFinalS2C.CreateBody(r,n)
            },
            {
                GamePacketID.Waypoint_Acc,
                (r,n) => Waypoint_Acc.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_LockCamera,
                (r,n) => S2C_LockCamera.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PlayVOAudioEvent,
                (r,n) => S2C_PlayVOAudioEvent.CreateBody(r,n)
            },
            {
                GamePacketID.AI_Command,
                (r,n) => AI_Command.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffRemove2,
                (r,n) => NPC_BuffRemove2.CreateBody(r,n)
            },
            {
                GamePacketID.SpawnMinionS2C,
                (r,n) => SpawnMinionS2C.CreateBody(r,n)
            },
            {
                GamePacketID.Unused125,
                (r,n) => Unused125.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ToggleFoW,
                (r,n) => S2C_ToggleFoW.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ToolTipVars,
                (r,n) => S2C_ToolTipVars.CreateBody(r,n)
            },
            {
                GamePacketID.Unused128,
                (r,n) => Unused128.CreateBody(r,n)
            },
            {
                GamePacketID.World_LockCamera_Server,
                (r,n) => World_LockCamera_Server.CreateBody(r,n)
            },
            {
                GamePacketID.BuyItemReq,
                (r,n) => BuyItemReq.CreateBody(r,n)
            },
            {
                GamePacketID.WaypointListHeroWithSpeed,
                (r,n) => WaypointListHeroWithSpeed.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetInputLockFlag,
                (r,n) => S2C_SetInputLockFlag.CreateBody(r,n)
            },
            {
                GamePacketID.CHAR_SetCooldown,
                (r,n) => CHAR_SetCooldown.CreateBody(r,n)
            },
            {
                GamePacketID.CHAR_CancelTargetingReticle,
                (r,n) => CHAR_CancelTargetingReticle.CreateBody(r,n)
            },
            {
                GamePacketID.FX_Create_Group,
                (r,n) => FX_Create_Group.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_QueryStatusAns,
                (r,n) => S2C_QueryStatusAns.CreateBody(r,n)
            },
            {
                GamePacketID.Building_Die,
                (r,n) => Building_Die.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PreloadCharacterData,
                (r,n) => S2C_PreloadCharacterData.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_RemoveListener,
                (r,n) => SPM_RemoveListener.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HandleQuestUpdate,
                (r,n) => S2C_HandleQuestUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_ClientFinished,
                (r,n) => C2S_ClientFinished.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_RemoveMemoryListener,
                (r,n) => SPM_RemoveMemoryListener.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_Exit,
                (r,n) => C2S_Exit.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ModifyDebugObjectColor,
                (r,n) => S2C_ModifyDebugObjectColor.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_AddListener,
                (r,n) => SPM_AddListener.CreateBody(r,n)
            },
            {
                GamePacketID.World_SendGameNumber,
                (r,n) => World_SendGameNumber.CreateBody(r,n)
            },
            {
                GamePacketID.SetPARState,
                (r,n) => SetPARState.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffRemoveGroup,
                (r,n) => NPC_BuffRemoveGroup.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_Ping_Load_Info,
                (r,n) => S2C_Ping_Load_Info.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ChangeCharacterVoice,
                (r,n) => S2C_ChangeCharacterVoice.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ChangeCharacterData,
                (r,n) => S2C_ChangeCharacterData.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_Exit,
                (r,n) => S2C_Exit.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_RemoveBBProfileListener,
                (r,n) => SPM_RemoveBBProfileListener.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_CastSpellReq,
                (r,n) => NPC_CastSpellReq.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ToggleInputLockFlag,
                (r,n) => S2C_ToggleInputLockFlag.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_SoftReconnect,
                (r,n) => C2S_SoftReconnect.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CreateTurret,
                (r,n) => S2C_CreateTurret.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_Die,
                (r,n) => NPC_Die.CreateBody(r,n)
            },
            {
                GamePacketID.UseItemAns,
                (r,n) => UseItemAns.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ShowAuxiliaryText,
                (r,n) => S2C_ShowAuxiliaryText.CreateBody(r,n)
            },
            {
                GamePacketID.PausePacket,
                (r,n) => PausePacket.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HideObjectiveText,
                (r,n) => S2C_HideObjectiveText.CreateBody(r,n)
            },
            {
                GamePacketID.OnEvent,
                (r,n) => OnEvent.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_TeamSurrenderVote,
                (r,n) => C2S_TeamSurrenderVote.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_TeamSurrenderStatus,
                (r,n) => S2C_TeamSurrenderStatus.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_AddBBProfileListener,
                (r,n) => SPM_AddBBProfileListener.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HideAuxiliaryText,
                (r,n) => S2C_HideAuxiliaryText.CreateBody(r,n)
            },
            {
                GamePacketID.OnReplication_Acc,
                (r,n) => OnReplication_Acc.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetGreyscaleEnabledWhenDead,
                (r,n) => S2C_SetGreyscaleEnabledWhenDead.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_AI_State,
                (r,n) => S2C_AI_State.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetFoWStatus,
                (r,n) => S2C_SetFoWStatus.CreateBody(r,n)
            },
            {
                GamePacketID.ReloadScripts,
                (r,n) => ReloadScripts.CreateBody(r,n)
            },
            {
                GamePacketID.Cheat,
                (r,n) => Cheat.CreateBody(r,n)
            },
            {
                GamePacketID.OnEnterLocalVisiblityClient,
                (r,n) => OnEnterLocalVisiblityClient.CreateBody(r,n)
            },
            {
                GamePacketID.SendSelectedObjID,
                (r,n) => SendSelectedObjID.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PlayAnimation,
                (r,n) => S2C_PlayAnimation.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_RefreshAuxiliaryText,
                (r,n) => S2C_RefreshAuxiliaryText.CreateBody(r,n)
            },
            {
                GamePacketID.SetFadeOut_Push,
                (r,n) => SetFadeOut_Push.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_OpenTutorialPopup,
                (r,n) => S2C_OpenTutorialPopup.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_RemoveUnitHighlight,
                (r,n) => S2C_RemoveUnitHighlight.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_CastSpellAns,
                (r,n) => NPC_CastSpellAns.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_HierarchicalBBProfileUpdate,
                (r,n) => SPM_HierarchicalBBProfileUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffAdd2,
                (r,n) => NPC_BuffAdd2.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_OpenAFKWarningMessage,
                (r,n) => S2C_OpenAFKWarningMessage.CreateBody(r,n)
            },
            {
                GamePacketID.WaypointList,
                (r,n) => WaypointList.CreateBody(r,n)
            },
            {
                GamePacketID.OnEnterVisiblityClient,
                (r,n) => OnEnterVisiblityClient.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_AddDebugObject,
                (r,n) => S2C_AddDebugObject.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_DisableHUDForEndOfGame,
                (r,n) => S2C_DisableHUDForEndOfGame.CreateBody(r,n)
            },
            {
                GamePacketID.SynchVersionC2S,
                (r,n) => SynchVersionC2S.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_CharSelected,
                (r,n) => C2S_CharSelected.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffUpdateCountGroup,
                (r,n) => NPC_BuffUpdateCountGroup.CreateBody(r,n)
            },
            {
                GamePacketID.AI_TargetHeroS2C,
                (r,n) => AI_TargetHeroS2C.CreateBody(r,n)
            },
            {
                GamePacketID.SynchSimTimeS2C,
                (r,n) => SynchSimTimeS2C.CreateBody(r,n)
            },
            {
                GamePacketID.SyncMissionStartTimeS2C,
                (r,n) => SyncMissionStartTimeS2C.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_Neutral_Camp_Empty,
                (r,n) => S2C_Neutral_Camp_Empty.CreateBody(r,n)
            },
            {
                GamePacketID.OnReplication,
                (r,n) => OnReplication.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_EndOfGameEvent,
                (r,n) => S2C_EndOfGameEvent.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_EndGame,
                (r,n) => S2C_EndGame.CreateBody(r,n)
            },
            {
                GamePacketID.SPM_SamplingProfilerUpdate,
                (r,n) => SPM_SamplingProfilerUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PopAllCharacterData,
                (r,n) => S2C_PopAllCharacterData.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_TeamSurrenderVote,
                (r,n) => S2C_TeamSurrenderVote.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HandleUIHighlight,
                (r,n) => S2C_HandleUIHighlight.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_FadeMinions,
                (r,n) => S2C_FadeMinions.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_OnTutorialPopupClosed,
                (r,n) => C2S_OnTutorialPopupClosed.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_OnQuestEvent,
                (r,n) => C2S_OnQuestEvent.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ShowHealthBar,
                (r,n) => S2C_ShowHealthBar.CreateBody(r,n)
            },
            {
                GamePacketID.SpawnBotS2C,
                (r,n) => SpawnBotS2C.CreateBody(r,n)
            },
            {
                GamePacketID.SpawnLevelPropS2C,
                (r,n) => SpawnLevelPropS2C.CreateBody(r,n)
            },
            {
                GamePacketID.UpdateLevelPropS2C,
                (r,n) => UpdateLevelPropS2C.CreateBody(r,n)
            },
            {
                GamePacketID.AttachFlexParticleS2C,
                (r,n) => AttachFlexParticleS2C.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HandleCapturePointUpdate,
                (r,n) => S2C_HandleCapturePointUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HandleGameScore,
                (r,n) => S2C_HandleGameScore.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_HandleRespawnPointUpdate,
                (r,n) => S2C_HandleRespawnPointUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_OnRespawnPointEvent,
                (r,n) => C2S_OnRespawnPointEvent.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitChangeTeam,
                (r,n) => S2C_UnitChangeTeam.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetMinimapIcon,
                (r,n) => S2C_UnitSetMinimapIcon.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_IncrementPlayerScore,
                (r,n) => S2C_IncrementPlayerScore.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_IncrementPlayerStat,
                (r,n) => S2C_IncrementPlayerStat.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ColorRemapFX,
                (r,n) => S2C_ColorRemapFX.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_InteractiveMusicCommand,
                (r,n) => S2C_InteractiveMusicCommand.CreateBody(r,n)
            },
            {
                GamePacketID.Unused221,
                (r,n) => Unused221.CreateBody(r,n)
            },
            {
                GamePacketID.Unused222,
                (r,n) => Unused222.CreateBody(r,n)
            },
            {
                GamePacketID.Unused223,
                (r,n) => Unused223.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_OnEnterTeamVisiblity,
                (r,n) => S2C_OnEnterTeamVisiblity.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_OnLeaveTeamVisiblity,
                (r,n) => S2C_OnLeaveTeamVisiblity.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_FX_OnEnterTeamVisiblity,
                (r,n) => S2C_FX_OnEnterTeamVisiblity.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_FX_OnLeaveTeamVisiblity,
                (r,n) => S2C_FX_OnLeaveTeamVisiblity.CreateBody(r,n)
            },
            {
                GamePacketID.ReplayOnly_GoldEarned,
                (r,n) => ReplayOnly_GoldEarned.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CloseClient,
                (r,n) => S2C_CloseClient.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_SpellChargeUpdateReq,
                (r,n) => C2S_SpellChargeUpdateReq.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ModifyDebugText,
                (r,n) => S2C_ModifyDebugText.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetDebugHidden,
                (r,n) => S2C_SetDebugHidden.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ActivateMinionCamp,
                (r,n) => S2C_ActivateMinionCamp.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_SpectatorDataReq,
                (r,n) => C2S_SpectatorDataReq.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SpectatorMetaData,
                (r,n) => S2C_SpectatorMetaData.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SpectatorDataChunkInfo,
                (r,n) => S2C_SpectatorDataChunkInfo.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SpectatorDataChunk,
                (r,n) => S2C_SpectatorDataChunk.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ChangeMissileTarget,
                (r,n) => S2C_ChangeMissileTarget.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_MarkOrSweepForSoftReconnect,
                (r,n) => S2C_MarkOrSweepForSoftReconnect.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetShopEnabled,
                (r,n) => S2C_SetShopEnabled.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CreateFollowerObject,
                (r,n) => S2C_CreateFollowerObject.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ReattachFollowerObject,
                (r,n) => S2C_ReattachFollowerObject.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_PlayContextualEmote,
                (r,n) => S2C_PlayContextualEmote.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_PlayContextualEmote,
                (r,n) => C2S_PlayContextualEmote.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetHoverIndicatorTarget,
                (r,n) => S2C_SetHoverIndicatorTarget.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetHoverIndicatorEnabled,
                (r,n) => S2C_SetHoverIndicatorEnabled.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SystemMessage,
                (r,n) => S2C_SystemMessage.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ChangeEmitterGroup,
                (r,n) => S2C_ChangeEmitterGroup.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UpdateRestrictedChatCount,
                (r,n) => S2C_UpdateRestrictedChatCount.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_TeamBalanceVote,
                (r,n) => S2C_TeamBalanceVote.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_TeamBalanceVote,
                (r,n) => C2S_TeamBalanceVote.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_TeamBalanceStatus,
                (r,n) => S2C_TeamBalanceStatus.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetItemCharges,
                (r,n) => S2C_SetItemCharges.CreateBody(r,n)
            },
            /*
            {
                GamePacketID.Batched,
                (r,n) => Batched.CreateBody(r,n)
            },
            */
            {
                GamePacketID.SpawnMarkerS2C,
                (r,n) => SpawnMarkerS2C.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetAutoAttackGroundAllowed,
                (r,n) => S2C_UnitSetAutoAttackGroundAllowed.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetShowAutoAttackIndicator,
                (r,n) => S2C_UnitSetShowAutoAttackIndicator.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_AnimationUpdateTimeStep,
                (r,n) => S2C_AnimationUpdateTimeStep.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetSpellPARCost,
                (r,n) => S2C_UnitSetSpellPARCost.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetDrawPathMode,
                (r,n) => S2C_UnitSetDrawPathMode.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_UnitSendDrawPath,
                (r,n) => C2S_UnitSendDrawPath.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_AmmoUpdate,
                (r,n) => S2C_AmmoUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetCursorReticle,
                (r,n) => S2C_UnitSetCursorReticle.CreateBody(r,n)
            },
            {
                GamePacketID.NPC_BuffUpdateNumCounter,
                (r,n) => NPC_BuffUpdateNumCounter.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_UndoItemReq,
                (r,n) => C2S_UndoItemReq.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetUndoEnabled,
                (r,n) => S2C_SetUndoEnabled.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetInventory,
                (r,n) => S2C_SetInventory.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ChangeMissileSpeed,
                (r,n) => S2C_ChangeMissileSpeed.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetCanSurrender,
                (r,n) => S2C_SetCanSurrender.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetLookAt,
                (r,n) => S2C_UnitSetLookAt.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_DestroyUnit,
                (r,n) => S2C_DestroyUnit.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetSpellLevelOverrides,
                (r,n) => S2C_UnitSetSpellLevelOverrides.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetMaxLevelOverride,
                (r,n) => S2C_UnitSetMaxLevelOverride.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnitSetPARType,
                (r,n) => S2C_UnitSetPARType.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_MoveMarker,
                (r,n) => S2C_MoveMarker.CreateBody(r,n)
            },
            {
                GamePacketID.ReplayOnly_MultiKillCountUpdate,
                (r,n) => ReplayOnly_MultiKillCountUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_NeutralMinionTimerUpdate,
                (r,n) => S2C_NeutralMinionTimerUpdate.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UpdateDeathTimer,
                (r,n) => S2C_UpdateDeathTimer.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UpdateSpellToggle,
                (r,n) => S2C_UpdateSpellToggle.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UpdateBounceMissile,
                (r,n) => S2C_UpdateBounceMissile.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_DebugLogGoldSources,
                (r,n) => S2C_DebugLogGoldSources.CreateBody(r,n)
            },
            {
                GamePacketID.C2S_CheatLogGoldSources,
                (r,n) => C2S_CheatLogGoldSources.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ShopItemSubstitutionSet,
                (r,n) => S2C_ShopItemSubstitutionSet.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ShopItemSubstitutionClear,
                (r,n) => S2C_ShopItemSubstitutionClear.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ResetClient,
                (r,n) => S2C_ResetClient.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_IncrementMinionKills,
                (r,n) => S2C_IncrementMinionKills.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UpdateAttackSpeedCapOverrides,
                (r,n) => S2C_UpdateAttackSpeedCapOverrides.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_NotifyContextualSituation,
                (r,n) => S2C_NotifyContextualSituation.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_CreateMinionCamp,
                (r,n) => S2C_CreateMinionCamp.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SpawnTurret,
                (r,n) => S2C_SpawnTurret.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UpdateAscended,
                (r,n) => S2C_UpdateAscended.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ChangeSpell_OwnerOnly,
                (r,n) => S2C_ChangeSpell_OwnerOnly.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_Die_MapView,
                (r,n) => S2C_Die_MapView.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetInventory_MapView,
                (r,n) => S2C_SetInventory_MapView.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_FloatingText2,
                (r,n) => S2C_FloatingText2.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_ForceTargetSpell,
                (r,n) => S2C_ForceTargetSpell.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_StopForceTargetSpell,
                (r,n) => S2C_StopForceTargetSpell.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_Guessed_LockCamera,
                (r,n) => S2C_Guessed_LockCamera.CreateBody(r,n)
            },
            {
                GamePacketID.UNK_0x12C,
                (r,n) => UNK_0x12C.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_SetFadeOut,
                (r,n) => S2C_SetFadeOut.CreateBody(r,n)
            },
            {
                GamePacketID.UNK_0x12E,
                (r,n) => UNK_0x12E.CreateBody(r,n)
            },
            {
                GamePacketID.S2C_UnlockAnimation,
                (r,n) => S2C_UnlockAnimation.CreateBody(r,n)
            },
        };
    }
}
