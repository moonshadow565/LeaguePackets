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
        private static readonly Dictionary<GamePacketID, Func<PacketReader, ChannelID, NetID, GamePacket>> _lookup
        = new Dictionary<GamePacketID, Func<PacketReader, ChannelID, NetID, GamePacket>>
        {
            {
                GamePacketID.Dummy,
                (r,c,n) => Dummy.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_HierarchicalProfilerUpdate,
                (r,c,n) => SPM_HierarchicalProfilerUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_DisplayLocalizedTutorialChatText,
                (r,c,n) => S2C_DisplayLocalizedTutorialChatText.CreateBody(r,c,n)
            },
            {
                GamePacketID.Barrack_SpawnUnit,
                (r,c,n) => Barrack_SpawnUnit.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SwitchNexusesToOnIdleParticles,
                (r,c,n) => S2C_SwitchNexusesToOnIdleParticles.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_TutorialAudioEventFinished,
                (r,c,n) => C2S_TutorialAudioEventFinished.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetCircularMovementRestriction,
                (r,c,n) => S2C_SetCircularMovementRestriction.CreateBody(r,c,n)
            },
            {
                GamePacketID.UpdateGoldRedirectTarget,
                (r,c,n) => UpdateGoldRedirectTarget.CreateBody(r,c,n)
            },
            {
                GamePacketID.SynchSimTimeC2S,
                (r,c,n) => SynchSimTimeC2S.CreateBody(r,c,n)
            },
            {
                GamePacketID.RemoveItemReq,
                (r,c,n) => RemoveItemReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.ResumePacket,
                (r,c,n) => ResumePacket.CreateBody(r,c,n)
            },
            {
                GamePacketID.RemoveItemAns,
                (r,c,n) => RemoveItemAns.CreateBody(r,c,n)
            },
            {
                GamePacketID.Basic_Attack,
                (r,c,n) => Basic_Attack.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ReplaceObjectiveText,
                (r,c,n) => S2C_ReplaceObjectiveText.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CloseShop,
                (r,c,n) => S2C_CloseShop.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_Reconnect,
                (r,c,n) => S2C_Reconnect.CreateBody(r,c,n)
            },
            {
                GamePacketID.UnitAddEXP,
                (r,c,n) => UnitAddEXP.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_EndSpawn,
                (r,c,n) => S2C_EndSpawn.CreateBody(r,c,n)
            },
            {
                GamePacketID.SetFrequency,
                (r,c,n) => SetFrequency.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_BotAI,
                (r,c,n) => S2C_BotAI.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_QueryStatusReq,
                (r,c,n) => C2S_QueryStatusReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_UpgradeSpellAns,
                (r,c,n) => NPC_UpgradeSpellAns.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_Ping_Load_Info,
                (r,c,n) => C2S_Ping_Load_Info.CreateBody(r,c,n)
            },
            {
                GamePacketID.ChangeSlotSpellData,
                (r,c,n) => ChangeSlotSpellData.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_MessageToClient,
                (r,c,n) => NPC_MessageToClient.CreateBody(r,c,n)
            },
            {
                GamePacketID.DisplayFloatingText,
                (r,c,n) => DisplayFloatingText.CreateBody(r,c,n)
            },
            {
                GamePacketID.Basic_Attack_Pos,
                (r,c,n) => Basic_Attack_Pos.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_ForceDead,
                (r,c,n) => NPC_ForceDead.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffUpdateCount,
                (r,c,n) => NPC_BuffUpdateCount.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_WriteNavFlags_Acc,
                (r,c,n) => C2S_WriteNavFlags_Acc.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffReplaceGroup,
                (r,c,n) => NPC_BuffReplaceGroup.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_SetAutocast,
                (r,c,n) => NPC_SetAutocast.CreateBody(r,c,n)
            },
            {
                GamePacketID.SwapItemReq,
                (r,c,n) => SwapItemReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_Die_EventHistory,
                (r,c,n) => NPC_Die_EventHistory.CreateBody(r,c,n)
            },
            {
                GamePacketID.UnitAddGold,
                (r,c,n) => UnitAddGold.CreateBody(r,c,n)
            },
            {
                GamePacketID.AddRegion,
                (r,c,n) => AddRegion.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_MoveRegion,
                (r,c,n) => S2C_MoveRegion.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_MoveCameraToPoint,
                (r,c,n) => S2C_MoveCameraToPoint.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_LineMissileHitList,
                (r,c,n) => S2C_LineMissileHitList.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_MuteVolumeCategory,
                (r,c,n) => S2C_MuteVolumeCategory.CreateBody(r,c,n)
            },
            {
                GamePacketID.ServerTick,
                (r,c,n) => ServerTick.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_StopAnimation,
                (r,c,n) => S2C_StopAnimation.CreateBody(r,c,n)
            },
            {
                GamePacketID.AvatarInfo_Server,
                (r,c,n) => AvatarInfo_Server.CreateBody(r,c,n)
            },
            {
                GamePacketID.DampenerSwitchStates,
                (r,c,n) => DampenerSwitchStates.CreateBody(r,c,n)
            },
            {
                GamePacketID.World_SendCamera_Server_Acknologment,
                (r,c,n) => World_SendCamera_Server_Acknologment.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ModifyDebugCircleRadius,
                (r,c,n) => S2C_ModifyDebugCircleRadius.CreateBody(r,c,n)
            },
            {
                GamePacketID.World_SendCamera_Server,
                (r,c,n) => World_SendCamera_Server.CreateBody(r,c,n)
            },
            {
                GamePacketID.HeroReincarnateAlive,
                (r,c,n) => HeroReincarnateAlive.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffReplace,
                (r,c,n) => NPC_BuffReplace.CreateBody(r,c,n)
            },
            {
                GamePacketID.Pause,
                (r,c,n) => Pause.CreateBody(r,c,n)
            },
            {
                GamePacketID.SetFadeOut_Pop,
                (r,c,n) => SetFadeOut_Pop.CreateBody(r,c,n)
            },
            {
                GamePacketID.RemoveRegion,
                (r,c,n) => RemoveRegion.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_InstantStop_Attack,
                (r,c,n) => NPC_InstantStop_Attack.CreateBody(r,c,n)
            },
            {
                GamePacketID.OnLeaveLocalVisiblityClient,
                (r,c,n) => OnLeaveLocalVisiblityClient.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ShowObjectiveText,
                (r,c,n) => S2C_ShowObjectiveText.CreateBody(r,c,n)
            },
            {
                GamePacketID.CHAR_SpawnPet,
                (r,c,n) => CHAR_SpawnPet.CreateBody(r,c,n)
            },
            {
                GamePacketID.FX_Kill,
                (r,c,n) => FX_Kill.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_UpgradeSpellReq,
                (r,c,n) => NPC_UpgradeSpellReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.UseObjectC2S,
                (r,c,n) => UseObjectC2S.CreateBody(r,c,n)
            },
            {
                GamePacketID.MissileReplication,
                (r,c,n) => MissileReplication.CreateBody(r,c,n)
            },
            {
                GamePacketID.MovementDriverReplication,
                (r,c,n) => MovementDriverReplication.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HighlightHUDElement,
                (r,c,n) => S2C_HighlightHUDElement.CreateBody(r,c,n)
            },
            {
                GamePacketID.SwapItemAns,
                (r,c,n) => SwapItemAns.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_LevelUp,
                (r,c,n) => NPC_LevelUp.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_MapPing,
                (r,c,n) => S2C_MapPing.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_WriteNavFlags,
                (r,c,n) => S2C_WriteNavFlags.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PlayEmote,
                (r,c,n) => S2C_PlayEmote.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PlaySound,
                (r,c,n) => S2C_PlaySound.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PlayVOCommand,
                (r,c,n) => S2C_PlayVOCommand.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_OnEventWorld,
                (r,c,n) => S2C_OnEventWorld.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HeroStats,
                (r,c,n) => S2C_HeroStats.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_UpdateGameOptions,
                (r,c,n) => C2S_UpdateGameOptions.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_PlayEmote,
                (r,c,n) => C2S_PlayEmote.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_PlayVOCommand,
                (r,c,n) => C2S_PlayVOCommand.CreateBody(r,c,n)
            },
            {
                GamePacketID.HeroReincarnate,
                (r,c,n) => HeroReincarnate.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_OnScoreBoardOpened,
                (r,c,n) => C2S_OnScoreBoardOpened.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CreateHero,
                (r,c,n) => S2C_CreateHero.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_AddMemoryListener,
                (r,c,n) => SPM_AddMemoryListener.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_HierarchicalMemoryUpdate,
                (r,c,n) => SPM_HierarchicalMemoryUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ToggleUIHighlight,
                (r,c,n) => S2C_ToggleUIHighlight.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_FaceDirection,
                (r,c,n) => S2C_FaceDirection.CreateBody(r,c,n)
            },
            {
                GamePacketID.OnLeaveVisiblityClient,
                (r,c,n) => OnLeaveVisiblityClient.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_ClientReady,
                (r,c,n) => C2S_ClientReady.CreateBody(r,c,n)
            },
            {
                GamePacketID.SetItem,
                (r,c,n) => SetItem.CreateBody(r,c,n)
            },
            {
                GamePacketID.SynchVersionS2C,
                (r,c,n) => SynchVersionS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HandleTipUpdate,
                (r,c,n) => S2C_HandleTipUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_StatsUpdateReq,
                (r,c,n) => C2S_StatsUpdateReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_MapPing,
                (r,c,n) => C2S_MapPing.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_RemoveDebugObject,
                (r,c,n) => S2C_RemoveDebugObject.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CreateUnitHighlight,
                (r,c,n) => S2C_CreateUnitHighlight.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_DestroyClientMissile,
                (r,c,n) => S2C_DestroyClientMissile.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetSpellLevel,
                (r,c,n) => S2C_SetSpellLevel.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_StartGame,
                (r,c,n) => S2C_StartGame.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_OnShopOpened,
                (r,c,n) => C2S_OnShopOpened.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_Hero_Die,
                (r,c,n) => NPC_Hero_Die.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_FadeOutMainSFX,
                (r,c,n) => S2C_FadeOutMainSFX.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PlayThemeMusic,
                (r,c,n) => S2C_PlayThemeMusic.CreateBody(r,c,n)
            },
            {
                GamePacketID.WaypointGroup,
                (r,c,n) => WaypointGroup.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_StartSpawn,
                (r,c,n) => S2C_StartSpawn.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CreateNeutral,
                (r,c,n) => S2C_CreateNeutral.CreateBody(r,c,n)
            },
            {
                GamePacketID.WaypointGroupWithSpeed,
                (r,c,n) => WaypointGroupWithSpeed.CreateBody(r,c,n)
            },
            {
                GamePacketID.UnitApplyDamage,
                (r,c,n) => UnitApplyDamage.CreateBody(r,c,n)
            },
            {
                GamePacketID.ModifyShield,
                (r,c,n) => ModifyShield.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PopCharacterData,
                (r,c,n) => S2C_PopCharacterData.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffAddGroup,
                (r,c,n) => NPC_BuffAddGroup.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_AI_TargetSelection,
                (r,c,n) => S2C_AI_TargetSelection.CreateBody(r,c,n)
            },
            {
                GamePacketID.AI_TargetS2C,
                (r,c,n) => AI_TargetS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetAnimStates,
                (r,c,n) => S2C_SetAnimStates.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ChainMissileSync,
                (r,c,n) => S2C_ChainMissileSync.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_OnTipEvent,
                (r,c,n) => C2S_OnTipEvent.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ForceCreateMissile,
                (r,c,n) => S2C_ForceCreateMissile.CreateBody(r,c,n)
            },
            {
                GamePacketID.BuyItemAns,
                (r,c,n) => BuyItemAns.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetSpellData,
                (r,c,n) => S2C_SetSpellData.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PauseAnimation,
                (r,c,n) => S2C_PauseAnimation.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_IssueOrderReq,
                (r,c,n) => NPC_IssueOrderReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CameraBehavior,
                (r,c,n) => S2C_CameraBehavior.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_AnimatedBuildingSetCurrentSkin,
                (r,c,n) => S2C_AnimatedBuildingSetCurrentSkin.CreateBody(r,c,n)
            },
            {
                GamePacketID.Connected,
                (r,c,n) => Connected.CreateBody(r,c,n)
            },
            {
                GamePacketID.SyncSimTimeFinalS2C,
                (r,c,n) => SyncSimTimeFinalS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.Waypoint_Acc,
                (r,c,n) => Waypoint_Acc.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_LockCamera,
                (r,c,n) => S2C_LockCamera.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PlayVOAudioEvent,
                (r,c,n) => S2C_PlayVOAudioEvent.CreateBody(r,c,n)
            },
            {
                GamePacketID.AI_Command,
                (r,c,n) => AI_Command.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffRemove2,
                (r,c,n) => NPC_BuffRemove2.CreateBody(r,c,n)
            },
            {
                GamePacketID.SpawnMinionS2C,
                (r,c,n) => SpawnMinionS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.Unused125,
                (r,c,n) => Unused125.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ToggleFoW,
                (r,c,n) => S2C_ToggleFoW.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ToolTipVars,
                (r,c,n) => S2C_ToolTipVars.CreateBody(r,c,n)
            },
            {
                GamePacketID.Unused128,
                (r,c,n) => Unused128.CreateBody(r,c,n)
            },
            {
                GamePacketID.World_LockCamera_Server,
                (r,c,n) => World_LockCamera_Server.CreateBody(r,c,n)
            },
            {
                GamePacketID.BuyItemReq,
                (r,c,n) => BuyItemReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.WaypointListHeroWithSpeed,
                (r,c,n) => WaypointListHeroWithSpeed.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetInputLockFlag,
                (r,c,n) => S2C_SetInputLockFlag.CreateBody(r,c,n)
            },
            {
                GamePacketID.CHAR_SetCooldown,
                (r,c,n) => CHAR_SetCooldown.CreateBody(r,c,n)
            },
            {
                GamePacketID.CHAR_CancelTargetingReticle,
                (r,c,n) => CHAR_CancelTargetingReticle.CreateBody(r,c,n)
            },
            {
                GamePacketID.FX_Create_Group,
                (r,c,n) => FX_Create_Group.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_QueryStatusAns,
                (r,c,n) => S2C_QueryStatusAns.CreateBody(r,c,n)
            },
            {
                GamePacketID.Building_Die,
                (r,c,n) => Building_Die.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PreloadCharacterData,
                (r,c,n) => S2C_PreloadCharacterData.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_RemoveListener,
                (r,c,n) => SPM_RemoveListener.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HandleQuestUpdate,
                (r,c,n) => S2C_HandleQuestUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_ClientFinished,
                (r,c,n) => C2S_ClientFinished.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_RemoveMemoryListener,
                (r,c,n) => SPM_RemoveMemoryListener.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_Exit,
                (r,c,n) => C2S_Exit.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ModifyDebugObjectColor,
                (r,c,n) => S2C_ModifyDebugObjectColor.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_AddListener,
                (r,c,n) => SPM_AddListener.CreateBody(r,c,n)
            },
            {
                GamePacketID.World_SendGameNumber,
                (r,c,n) => World_SendGameNumber.CreateBody(r,c,n)
            },
            {
                GamePacketID.SetPARState,
                (r,c,n) => SetPARState.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffRemoveGroup,
                (r,c,n) => NPC_BuffRemoveGroup.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_Ping_Load_Info,
                (r,c,n) => S2C_Ping_Load_Info.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeCharacterVoice,
                (r,c,n) => S2C_ChangeCharacterVoice.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeCharacterData,
                (r,c,n) => S2C_ChangeCharacterData.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_Exit,
                (r,c,n) => S2C_Exit.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_RemoveBBProfileListener,
                (r,c,n) => SPM_RemoveBBProfileListener.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_CastSpellReq,
                (r,c,n) => NPC_CastSpellReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ToggleInputLockFlag,
                (r,c,n) => S2C_ToggleInputLockFlag.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_SoftReconnect,
                (r,c,n) => C2S_SoftReconnect.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CreateTurret,
                (r,c,n) => S2C_CreateTurret.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_Die,
                (r,c,n) => NPC_Die.CreateBody(r,c,n)
            },
            {
                GamePacketID.UseItemAns,
                (r,c,n) => UseItemAns.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ShowAuxiliaryText,
                (r,c,n) => S2C_ShowAuxiliaryText.CreateBody(r,c,n)
            },
            {
                GamePacketID.PausePacket,
                (r,c,n) => PausePacket.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HideObjectiveText,
                (r,c,n) => S2C_HideObjectiveText.CreateBody(r,c,n)
            },
            {
                GamePacketID.OnEvent,
                (r,c,n) => OnEvent.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_TeamSurrenderVote,
                (r,c,n) => C2S_TeamSurrenderVote.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_TeamSurrenderStatus,
                (r,c,n) => S2C_TeamSurrenderStatus.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_AddBBProfileListener,
                (r,c,n) => SPM_AddBBProfileListener.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HideAuxiliaryText,
                (r,c,n) => S2C_HideAuxiliaryText.CreateBody(r,c,n)
            },
            {
                GamePacketID.OnReplication_Acc,
                (r,c,n) => OnReplication_Acc.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetGreyscaleEnabledWhenDead,
                (r,c,n) => S2C_SetGreyscaleEnabledWhenDead.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_AI_State,
                (r,c,n) => S2C_AI_State.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetFoWStatus,
                (r,c,n) => S2C_SetFoWStatus.CreateBody(r,c,n)
            },
            {
                GamePacketID.ReloadScripts,
                (r,c,n) => ReloadScripts.CreateBody(r,c,n)
            },
            {
                GamePacketID.Cheat,
                (r,c,n) => Cheat.CreateBody(r,c,n)
            },
            {
                GamePacketID.OnEnterLocalVisiblityClient,
                (r,c,n) => OnEnterLocalVisiblityClient.CreateBody(r,c,n)
            },
            {
                GamePacketID.SendSelectedObjID,
                (r,c,n) => SendSelectedObjID.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PlayAnimation,
                (r,c,n) => S2C_PlayAnimation.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_RefreshAuxiliaryText,
                (r,c,n) => S2C_RefreshAuxiliaryText.CreateBody(r,c,n)
            },
            {
                GamePacketID.SetFadeOut_Push,
                (r,c,n) => SetFadeOut_Push.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_OpenTutorialPopup,
                (r,c,n) => S2C_OpenTutorialPopup.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_RemoveUnitHighlight,
                (r,c,n) => S2C_RemoveUnitHighlight.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_CastSpellAns,
                (r,c,n) => NPC_CastSpellAns.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_HierarchicalBBProfileUpdate,
                (r,c,n) => SPM_HierarchicalBBProfileUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffAdd2,
                (r,c,n) => NPC_BuffAdd2.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_OpenAFKWarningMessage,
                (r,c,n) => S2C_OpenAFKWarningMessage.CreateBody(r,c,n)
            },
            {
                GamePacketID.WaypointList,
                (r,c,n) => WaypointList.CreateBody(r,c,n)
            },
            {
                GamePacketID.OnEnterVisiblityClient,
                (r,c,n) => OnEnterVisiblityClient.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_AddDebugObject,
                (r,c,n) => S2C_AddDebugObject.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_DisableHUDForEndOfGame,
                (r,c,n) => S2C_DisableHUDForEndOfGame.CreateBody(r,c,n)
            },
            {
                GamePacketID.SynchVersionC2S,
                (r,c,n) => SynchVersionC2S.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_CharSelected,
                (r,c,n) => C2S_CharSelected.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffUpdateCountGroup,
                (r,c,n) => NPC_BuffUpdateCountGroup.CreateBody(r,c,n)
            },
            {
                GamePacketID.AI_TargetHeroS2C,
                (r,c,n) => AI_TargetHeroS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.SynchSimTimeS2C,
                (r,c,n) => SynchSimTimeS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.SyncMissionStartTimeS2C,
                (r,c,n) => SyncMissionStartTimeS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_Neutral_Camp_Empty,
                (r,c,n) => S2C_Neutral_Camp_Empty.CreateBody(r,c,n)
            },
            {
                GamePacketID.OnReplication,
                (r,c,n) => OnReplication.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_EndOfGameEvent,
                (r,c,n) => S2C_EndOfGameEvent.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_EndGame,
                (r,c,n) => S2C_EndGame.CreateBody(r,c,n)
            },
            {
                GamePacketID.SPM_SamplingProfilerUpdate,
                (r,c,n) => SPM_SamplingProfilerUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PopAllCharacterData,
                (r,c,n) => S2C_PopAllCharacterData.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_TeamSurrenderVote,
                (r,c,n) => S2C_TeamSurrenderVote.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HandleUIHighlight,
                (r,c,n) => S2C_HandleUIHighlight.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_FadeMinions,
                (r,c,n) => S2C_FadeMinions.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_OnTutorialPopupClosed,
                (r,c,n) => C2S_OnTutorialPopupClosed.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_OnQuestEvent,
                (r,c,n) => C2S_OnQuestEvent.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ShowHealthBar,
                (r,c,n) => S2C_ShowHealthBar.CreateBody(r,c,n)
            },
            {
                GamePacketID.SpawnBotS2C,
                (r,c,n) => SpawnBotS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.SpawnLevelPropS2C,
                (r,c,n) => SpawnLevelPropS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.UpdateLevelPropS2C,
                (r,c,n) => UpdateLevelPropS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.AttachFlexParticleS2C,
                (r,c,n) => AttachFlexParticleS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HandleCapturePointUpdate,
                (r,c,n) => S2C_HandleCapturePointUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HandleGameScore,
                (r,c,n) => S2C_HandleGameScore.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_HandleRespawnPointUpdate,
                (r,c,n) => S2C_HandleRespawnPointUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_OnRespawnPointEvent,
                (r,c,n) => C2S_OnRespawnPointEvent.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitChangeTeam,
                (r,c,n) => S2C_UnitChangeTeam.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetMinimapIcon,
                (r,c,n) => S2C_UnitSetMinimapIcon.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_IncrementPlayerScore,
                (r,c,n) => S2C_IncrementPlayerScore.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_IncrementPlayerStat,
                (r,c,n) => S2C_IncrementPlayerStat.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ColorRemapFX,
                (r,c,n) => S2C_ColorRemapFX.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_InteractiveMusicCommand,
                (r,c,n) => S2C_InteractiveMusicCommand.CreateBody(r,c,n)
            },
            {
                GamePacketID.Unused221,
                (r,c,n) => Unused221.CreateBody(r,c,n)
            },
            {
                GamePacketID.Unused222,
                (r,c,n) => Unused222.CreateBody(r,c,n)
            },
            {
                GamePacketID.Unused223,
                (r,c,n) => Unused223.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_OnEnterTeamVisiblity,
                (r,c,n) => S2C_OnEnterTeamVisiblity.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_OnLeaveTeamVisiblity,
                (r,c,n) => S2C_OnLeaveTeamVisiblity.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_FX_OnEnterTeamVisiblity,
                (r,c,n) => S2C_FX_OnEnterTeamVisiblity.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_FX_OnLeaveTeamVisiblity,
                (r,c,n) => S2C_FX_OnLeaveTeamVisiblity.CreateBody(r,c,n)
            },
            {
                GamePacketID.ReplayOnly_GoldEarned,
                (r,c,n) => ReplayOnly_GoldEarned.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CloseClient,
                (r,c,n) => S2C_CloseClient.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_SpellChargeUpdateReq,
                (r,c,n) => C2S_SpellChargeUpdateReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ModifyDebugText,
                (r,c,n) => S2C_ModifyDebugText.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetDebugHidden,
                (r,c,n) => S2C_SetDebugHidden.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ActivateMinionCamp,
                (r,c,n) => S2C_ActivateMinionCamp.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_SpectatorDataReq,
                (r,c,n) => C2S_SpectatorDataReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SpectatorMetaData,
                (r,c,n) => S2C_SpectatorMetaData.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SpectatorDataChunkInfo,
                (r,c,n) => S2C_SpectatorDataChunkInfo.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SpectatorDataChunk,
                (r,c,n) => S2C_SpectatorDataChunk.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeMissileTarget,
                (r,c,n) => S2C_ChangeMissileTarget.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_MarkOrSweepForSoftReconnect,
                (r,c,n) => S2C_MarkOrSweepForSoftReconnect.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetShopEnabled,
                (r,c,n) => S2C_SetShopEnabled.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CreateFollowerObject,
                (r,c,n) => S2C_CreateFollowerObject.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ReattachFollowerObject,
                (r,c,n) => S2C_ReattachFollowerObject.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_PlayContextualEmote,
                (r,c,n) => S2C_PlayContextualEmote.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_PlayContextualEmote,
                (r,c,n) => C2S_PlayContextualEmote.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetHoverIndicatorTarget,
                (r,c,n) => S2C_SetHoverIndicatorTarget.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetHoverIndicatorEnabled,
                (r,c,n) => S2C_SetHoverIndicatorEnabled.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SystemMessage,
                (r,c,n) => S2C_SystemMessage.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeEmitterGroup,
                (r,c,n) => S2C_ChangeEmitterGroup.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateRestrictedChatCount,
                (r,c,n) => S2C_UpdateRestrictedChatCount.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_TeamBalanceVote,
                (r,c,n) => S2C_TeamBalanceVote.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_TeamBalanceVote,
                (r,c,n) => C2S_TeamBalanceVote.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_TeamBalanceStatus,
                (r,c,n) => S2C_TeamBalanceStatus.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetItemCharges,
                (r,c,n) => S2C_SetItemCharges.CreateBody(r,c,n)
            },
            /*
            {
                GamePacketID.Batched,
                (r,c,n) => Batched.CreateBody(r,c,n)
            },
            */
            {
                GamePacketID.SpawnMarkerS2C,
                (r,c,n) => SpawnMarkerS2C.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetAutoAttackGroundAllowed,
                (r,c,n) => S2C_UnitSetAutoAttackGroundAllowed.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetShowAutoAttackIndicator,
                (r,c,n) => S2C_UnitSetShowAutoAttackIndicator.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_AnimationUpdateTimeStep,
                (r,c,n) => S2C_AnimationUpdateTimeStep.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetSpellPARCost,
                (r,c,n) => S2C_UnitSetSpellPARCost.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetDrawPathMode,
                (r,c,n) => S2C_UnitSetDrawPathMode.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_UnitSendDrawPath,
                (r,c,n) => C2S_UnitSendDrawPath.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_AmmoUpdate,
                (r,c,n) => S2C_AmmoUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetCursorReticle,
                (r,c,n) => S2C_UnitSetCursorReticle.CreateBody(r,c,n)
            },
            {
                GamePacketID.NPC_BuffUpdateNumCounter,
                (r,c,n) => NPC_BuffUpdateNumCounter.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_UndoItemReq,
                (r,c,n) => C2S_UndoItemReq.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetUndoEnabled,
                (r,c,n) => S2C_SetUndoEnabled.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetInventory,
                (r,c,n) => S2C_SetInventory.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeMissileSpeed,
                (r,c,n) => S2C_ChangeMissileSpeed.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetCanSurrender,
                (r,c,n) => S2C_SetCanSurrender.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetLookAt,
                (r,c,n) => S2C_UnitSetLookAt.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_DestroyUnit,
                (r,c,n) => S2C_DestroyUnit.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetSpellLevelOverrides,
                (r,c,n) => S2C_UnitSetSpellLevelOverrides.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetMaxLevelOverride,
                (r,c,n) => S2C_UnitSetMaxLevelOverride.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetPARType,
                (r,c,n) => S2C_UnitSetPARType.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_MoveMarker,
                (r,c,n) => S2C_MoveMarker.CreateBody(r,c,n)
            },
            {
                GamePacketID.ReplayOnly_MultiKillCountUpdate,
                (r,c,n) => ReplayOnly_MultiKillCountUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_NeutralMinionTimerUpdate,
                (r,c,n) => S2C_NeutralMinionTimerUpdate.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateDeathTimer,
                (r,c,n) => S2C_UpdateDeathTimer.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateSpellToggle,
                (r,c,n) => S2C_UpdateSpellToggle.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateBounceMissile,
                (r,c,n) => S2C_UpdateBounceMissile.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_DebugLogGoldSources,
                (r,c,n) => S2C_DebugLogGoldSources.CreateBody(r,c,n)
            },
            {
                GamePacketID.C2S_CheatLogGoldSources,
                (r,c,n) => C2S_CheatLogGoldSources.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ShopItemSubstitutionSet,
                (r,c,n) => S2C_ShopItemSubstitutionSet.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ShopItemSubstitutionClear,
                (r,c,n) => S2C_ShopItemSubstitutionClear.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ResetClient,
                (r,c,n) => S2C_ResetClient.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_IncrementMinionKills,
                (r,c,n) => S2C_IncrementMinionKills.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateAttackSpeedCapOverrides,
                (r,c,n) => S2C_UpdateAttackSpeedCapOverrides.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_NotifyContextualSituation,
                (r,c,n) => S2C_NotifyContextualSituation.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_CreateMinionCamp,
                (r,c,n) => S2C_CreateMinionCamp.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SpawnTurret,
                (r,c,n) => S2C_SpawnTurret.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateAscended,
                (r,c,n) => S2C_UpdateAscended.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeSpell_OwnerOnly,
                (r,c,n) => S2C_ChangeSpell_OwnerOnly.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_Die_MapView,
                (r,c,n) => S2C_Die_MapView.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetInventory_MapView,
                (r,c,n) => S2C_SetInventory_MapView.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_FloatingText2,
                (r,c,n) => S2C_FloatingText2.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_ForceTargetSpell,
                (r,c,n) => S2C_ForceTargetSpell.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_StopForceTargetSpell,
                (r,c,n) => S2C_StopForceTargetSpell.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_Guessed_LockCamera,
                (r,c,n) => S2C_Guessed_LockCamera.CreateBody(r,c,n)
            },
            {
                GamePacketID.UNK_0x12C,
                (r,c,n) => UNK_0x12C.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_SetFadeOut,
                (r,c,n) => S2C_SetFadeOut.CreateBody(r,c,n)
            },
            {
                GamePacketID.UNK_0x12E,
                (r,c,n) => UNK_0x12E.CreateBody(r,c,n)
            },
            {
                GamePacketID.S2C_UnlockAnimation,
                (r,c,n) => S2C_UnlockAnimation.CreateBody(r,c,n)
            },
        };
    }
}
