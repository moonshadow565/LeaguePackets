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
    public static partial class GamePacketExtension
    {
        private static readonly Dictionary<GamePacketID, Func<PacketReader, ChannelID, NetID, GamePacket>> _lookup
        = new Dictionary<GamePacketID, Func<PacketReader, ChannelID, NetID, GamePacket>>
        {
            {
                GamePacketID.Dummy,
                (r,c,n) => new Dummy(r,c,n)
            },
            {
                GamePacketID.SPM_HierarchicalProfilerUpdate,
                (r,c,n) => new SPM_HierarchicalProfilerUpdate(r,c,n)
            },
            {
                GamePacketID.S2C_DisplayLocalizedTutorialChatText,
                (r,c,n) => new S2C_DisplayLocalizedTutorialChatText(r,c,n)
            },
            {
                GamePacketID.Barrack_SpawnUnit,
                (r,c,n) => new Barrack_SpawnUnit(r,c,n)
            },
            {
                GamePacketID.S2C_SwitchNexusesToOnIdleParticles,
                (r,c,n) => new S2C_SwitchNexusesToOnIdleParticles(r,c,n)
            },
            {
                GamePacketID.C2S_TutorialAudioEventFinished,
                (r,c,n) => new C2S_TutorialAudioEventFinished(r,c,n)
            },
            {
                GamePacketID.S2C_SetCircularMovementRestriction,
                (r,c,n) => new S2C_SetCircularMovementRestriction(r,c,n)
            },
            {
                GamePacketID.UpdateGoldRedirectTarget,
                (r,c,n) => new UpdateGoldRedirectTarget(r,c,n)
            },
            {
                GamePacketID.SynchSimTimeC2S,
                (r,c,n) => new SynchSimTimeC2S(r,c,n)
            },
            {
                GamePacketID.RemoveItemReq,
                (r,c,n) => new RemoveItemReq(r,c,n)
            },
            {
                GamePacketID.ResumePacket,
                (r,c,n) => new ResumePacket(r,c,n)
            },
            {
                GamePacketID.RemoveItemAns,
                (r,c,n) => new RemoveItemAns(r,c,n)
            },
            {
                GamePacketID.Basic_Attack,
                (r,c,n) => new Basic_Attack(r,c,n)
            },
            {
                GamePacketID.S2C_ReplaceObjectiveText,
                (r,c,n) => new S2C_ReplaceObjectiveText(r,c,n)
            },
            {
                GamePacketID.S2C_CloseShop,
                (r,c,n) => new S2C_CloseShop(r,c,n)
            },
            {
                GamePacketID.S2C_Reconnect,
                (r,c,n) => new S2C_Reconnect(r,c,n)
            },
            {
                GamePacketID.UnitAddEXP,
                (r,c,n) => new UnitAddEXP(r,c,n)
            },
            {
                GamePacketID.S2C_EndSpawn,
                (r,c,n) => new S2C_EndSpawn(r,c,n)
            },
            {
                GamePacketID.SetFrequency,
                (r,c,n) => new SetFrequency(r,c,n)
            },
            {
                GamePacketID.S2C_BotAI,
                (r,c,n) => new S2C_BotAI(r,c,n)
            },
            {
                GamePacketID.C2S_QueryStatusReq,
                (r,c,n) => new C2S_QueryStatusReq(r,c,n)
            },
            {
                GamePacketID.NPC_UpgradeSpellAns,
                (r,c,n) => new NPC_UpgradeSpellAns(r,c,n)
            },
            {
                GamePacketID.C2S_Ping_Load_Info,
                (r,c,n) => new C2S_Ping_Load_Info(r,c,n)
            },
            {
                GamePacketID.ChangeSlotSpellData,
                (r,c,n) => new ChangeSlotSpellData(r,c,n)
            },
            {
                GamePacketID.NPC_MessageToClient_Broadcast,
                (r,c,n) => new NPC_MessageToClient_Broadcast(r,c,n)
            },
            {
                GamePacketID.DisplayFloatingText,
                (r,c,n) => new DisplayFloatingText(r,c,n)
            },
            {
                GamePacketID.Basic_Attack_Pos,
                (r,c,n) => new Basic_Attack_Pos(r,c,n)
            },
            {
                GamePacketID.NPC_ForceDead,
                (r,c,n) => new NPC_ForceDead(r,c,n)
            },
            {
                GamePacketID.NPC_BuffUpdateCount,
                (r,c,n) => new NPC_BuffUpdateCount(r,c,n)
            },
            {
                GamePacketID.C2S_WriteNavFlags_Acc,
                (r,c,n) => new C2S_WriteNavFlags_Acc(r,c,n)
            },
            {
                GamePacketID.NPC_BuffReplaceGroup,
                (r,c,n) => new NPC_BuffReplaceGroup(r,c,n)
            },
            {
                GamePacketID.NPC_SetAutocast,
                (r,c,n) => new NPC_SetAutocast(r,c,n)
            },
            {
                GamePacketID.SwapItemReq,
                (r,c,n) => new SwapItemReq(r,c,n)
            },
            {
                GamePacketID.NPC_Die_EventHistory,
                (r,c,n) => new NPC_Die_EventHistory(r,c,n)
            },
            {
                GamePacketID.UnitAddGold,
                (r,c,n) => new UnitAddGold(r,c,n)
            },
            {
                GamePacketID.AddRegion,
                (r,c,n) => new AddRegion(r,c,n)
            },
            {
                GamePacketID.S2C_MoveRegion,
                (r,c,n) => new S2C_MoveRegion(r,c,n)
            },
            {
                GamePacketID.S2C_MoveCameraToPoint,
                (r,c,n) => new S2C_MoveCameraToPoint(r,c,n)
            },
            {
                GamePacketID.S2C_LineMissileHitList,
                (r,c,n) => new S2C_LineMissileHitList(r,c,n)
            },
            {
                GamePacketID.S2C_MuteVolumeCategory,
                (r,c,n) => new S2C_MuteVolumeCategory(r,c,n)
            },
            {
                GamePacketID.ServerTick,
                (r,c,n) => new ServerTick(r,c,n)
            },
            {
                GamePacketID.S2C_StopAnimation,
                (r,c,n) => new S2C_StopAnimation(r,c,n)
            },
            {
                GamePacketID.AvatarInfo_Server,
                (r,c,n) => new AvatarInfo_Server(r,c,n)
            },
            {
                GamePacketID.DampenerSwitchStates,
                (r,c,n) => new DampenerSwitchStates(r,c,n)
            },
            {
                GamePacketID.World_SendCamera_Server_Acknologment,
                (r,c,n) => new World_SendCamera_Server_Acknologment(r,c,n)
            },
            {
                GamePacketID.S2C_ModifyDebugCircleRadius,
                (r,c,n) => new S2C_ModifyDebugCircleRadius(r,c,n)
            },
            {
                GamePacketID.World_SendCamera_Server,
                (r,c,n) => new World_SendCamera_Server(r,c,n)
            },
            {
                GamePacketID.HeroReincarnateAlive,
                (r,c,n) => new HeroReincarnateAlive(r,c,n)
            },
            {
                GamePacketID.NPC_BuffReplace,
                (r,c,n) => new NPC_BuffReplace(r,c,n)
            },
            {
                GamePacketID.Pause,
                (r,c,n) => new Pause(r,c,n)
            },
            {
                GamePacketID.SetFadeOut_Pop,
                (r,c,n) => new SetFadeOut_Pop(r,c,n)
            },
            {
                GamePacketID.RemoveRegion,
                (r,c,n) => new RemoveRegion(r,c,n)
            },
            {
                GamePacketID.NPC_InstantStop_Attack,
                (r,c,n) => new NPC_InstantStop_Attack(r,c,n)
            },
            {
                GamePacketID.OnLeaveLocalVisiblityClient,
                (r,c,n) => new OnLeaveLocalVisiblityClient(r,c,n)
            },
            {
                GamePacketID.S2C_ShowObjectiveText,
                (r,c,n) => new S2C_ShowObjectiveText(r,c,n)
            },
            {
                GamePacketID.CHAR_SpawnPet,
                (r,c,n) => new CHAR_SpawnPet(r,c,n)
            },
            {
                GamePacketID.FX_Kill,
                (r,c,n) => new FX_Kill(r,c,n)
            },
            {
                GamePacketID.NPC_UpgradeSpellReq,
                (r,c,n) => new NPC_UpgradeSpellReq(r,c,n)
            },
            {
                GamePacketID.UseObjectC2S,
                (r,c,n) => new UseObjectC2S(r,c,n)
            },
            {
                GamePacketID.MissileReplication,
                (r,c,n) => new MissileReplication(r,c,n)
            },
            {
                GamePacketID.MovementDriverReplication,
                (r,c,n) => new MovementDriverReplication(r,c,n)
            },
            {
                GamePacketID.S2C_HighlightHUDElement,
                (r,c,n) => new S2C_HighlightHUDElement(r,c,n)
            },
            {
                GamePacketID.SwapItemAns,
                (r,c,n) => new SwapItemAns(r,c,n)
            },
            {
                GamePacketID.NPC_LevelUp,
                (r,c,n) => new NPC_LevelUp(r,c,n)
            },
            {
                GamePacketID.S2C_MapPing,
                (r,c,n) => new S2C_MapPing(r,c,n)
            },
            {
                GamePacketID.S2C_WriteNavFlags,
                (r,c,n) => new S2C_WriteNavFlags(r,c,n)
            },
            {
                GamePacketID.S2C_PlayEmote,
                (r,c,n) => new S2C_PlayEmote(r,c,n)
            },
            {
                GamePacketID.S2C_PlaySound,
                (r,c,n) => new S2C_PlaySound(r,c,n)
            },
            {
                GamePacketID.S2C_PlayVOCommand,
                (r,c,n) => new S2C_PlayVOCommand(r,c,n)
            },
            {
                GamePacketID.S2C_OnEventWorld,
                (r,c,n) => new S2C_OnEventWorld(r,c,n)
            },
            {
                GamePacketID.S2C_HeroStats,
                (r,c,n) => new S2C_HeroStats(r,c,n)
            },
            {
                GamePacketID.C2S_UpdateGameOptions,
                (r,c,n) => new C2S_UpdateGameOptions(r,c,n)
            },
            {
                GamePacketID.C2S_PlayEmote,
                (r,c,n) => new C2S_PlayEmote(r,c,n)
            },
            {
                GamePacketID.C2S_PlayVOCommand,
                (r,c,n) => new C2S_PlayVOCommand(r,c,n)
            },
            {
                GamePacketID.HeroReincarnate,
                (r,c,n) => new HeroReincarnate(r,c,n)
            },
            {
                GamePacketID.C2S_OnScoreBoardOpened,
                (r,c,n) => new C2S_OnScoreBoardOpened(r,c,n)
            },
            {
                GamePacketID.S2C_CreateHero,
                (r,c,n) => new S2C_CreateHero(r,c,n)
            },
            {
                GamePacketID.SPM_AddMemoryListener,
                (r,c,n) => new SPM_AddMemoryListener(r,c,n)
            },
            {
                GamePacketID.SPM_HierarchicalMemoryUpdate,
                (r,c,n) => new SPM_HierarchicalMemoryUpdate(r,c,n)
            },
            {
                GamePacketID.S2C_ToggleUIHighlight,
                (r,c,n) => new S2C_ToggleUIHighlight(r,c,n)
            },
            {
                GamePacketID.S2C_FaceDirection,
                (r,c,n) => new S2C_FaceDirection(r,c,n)
            },
            {
                GamePacketID.OnLeaveVisiblityClient,
                (r,c,n) => new OnLeaveVisiblityClient(r,c,n)
            },
            {
                GamePacketID.C2S_ClientReady,
                (r,c,n) => new C2S_ClientReady(r,c,n)
            },
            {
                GamePacketID.SetItem,
                (r,c,n) => new SetItem(r,c,n)
            },
            {
                GamePacketID.SynchVersionS2C,
                (r,c,n) => new SynchVersionS2C(r,c,n)
            },
            {
                GamePacketID.S2C_HandleTipUpdate,
                (r,c,n) => new S2C_HandleTipUpdate(r,c,n)
            },
            {
                GamePacketID.C2S_StatsUpdateReq,
                (r,c,n) => new C2S_StatsUpdateReq(r,c,n)
            },
            {
                GamePacketID.C2S_MapPing,
                (r,c,n) => new C2S_MapPing(r,c,n)
            },
            {
                GamePacketID.S2C_RemoveDebugObject,
                (r,c,n) => new S2C_RemoveDebugObject(r,c,n)
            },
            {
                GamePacketID.S2C_CreateUnitHighlight,
                (r,c,n) => new S2C_CreateUnitHighlight(r,c,n)
            },
            {
                GamePacketID.S2C_DestroyClientMissile,
                (r,c,n) => new S2C_DestroyClientMissile(r,c,n)
            },
            {
                GamePacketID.S2C_SetSpellLevel,
                (r,c,n) => new S2C_SetSpellLevel(r,c,n)
            },
            {
                GamePacketID.S2C_StartGame,
                (r,c,n) => new S2C_StartGame(r,c,n)
            },
            {
                GamePacketID.C2S_OnShopOpened,
                (r,c,n) => new C2S_OnShopOpened(r,c,n)
            },
            {
                GamePacketID.NPC_Hero_Die,
                (r,c,n) => new NPC_Hero_Die(r,c,n)
            },
            {
                GamePacketID.S2C_FadeOutMainSFX,
                (r,c,n) => new S2C_FadeOutMainSFX(r,c,n)
            },
            {
                GamePacketID.S2C_PlayThemeMusic,
                (r,c,n) => new S2C_PlayThemeMusic(r,c,n)
            },
            {
                GamePacketID.WaypointGroup,
                (r,c,n) => new WaypointGroup(r,c,n)
            },
            {
                GamePacketID.S2C_StartSpawn,
                (r,c,n) => new S2C_StartSpawn(r,c,n)
            },
            {
                GamePacketID.S2C_CreateNeutral,
                (r,c,n) => new S2C_CreateNeutral(r,c,n)
            },
            {
                GamePacketID.WaypointGroupWithSpeed,
                (r,c,n) => new WaypointGroupWithSpeed(r,c,n)
            },
            {
                GamePacketID.UnitApplyDamage,
                (r,c,n) => new UnitApplyDamage(r,c,n)
            },
            {
                GamePacketID.ModifyShield,
                (r,c,n) => new ModifyShield(r,c,n)
            },
            {
                GamePacketID.S2C_PopCharacterData,
                (r,c,n) => new S2C_PopCharacterData(r,c,n)
            },
            {
                GamePacketID.NPC_BuffAddGroup,
                (r,c,n) => new NPC_BuffAddGroup(r,c,n)
            },
            {
                GamePacketID.S2C_AI_TargetSelection,
                (r,c,n) => new S2C_AI_TargetSelection(r,c,n)
            },
            {
                GamePacketID.AI_TargetS2C,
                (r,c,n) => new AI_TargetS2C(r,c,n)
            },
            {
                GamePacketID.S2C_SetAnimStates,
                (r,c,n) => new S2C_SetAnimStates(r,c,n)
            },
            {
                GamePacketID.S2C_ChainMissileSync,
                (r,c,n) => new S2C_ChainMissileSync(r,c,n)
            },
            {
                GamePacketID.C2S_OnTipEvent,
                (r,c,n) => new C2S_OnTipEvent(r,c,n)
            },
            {
                GamePacketID.S2C_ForceCreateMissile,
                (r,c,n) => new S2C_ForceCreateMissile(r,c,n)
            },
            {
                GamePacketID.BuyItemAns,
                (r,c,n) => new BuyItemAns(r,c,n)
            },
            {
                GamePacketID.S2C_SetSpellData,
                (r,c,n) => new S2C_SetSpellData(r,c,n)
            },
            {
                GamePacketID.S2C_PauseAnimation,
                (r,c,n) => new S2C_PauseAnimation(r,c,n)
            },
            {
                GamePacketID.NPC_IssueOrderReq,
                (r,c,n) => new NPC_IssueOrderReq(r,c,n)
            },
            {
                GamePacketID.S2C_CameraBehavior,
                (r,c,n) => new S2C_CameraBehavior(r,c,n)
            },
            {
                GamePacketID.S2C_AnimatedBuildingSetCurrentSkin,
                (r,c,n) => new S2C_AnimatedBuildingSetCurrentSkin(r,c,n)
            },
            {
                GamePacketID.Connected,
                (r,c,n) => new Connected(r,c,n)
            },
            {
                GamePacketID.SyncSimTimeFinalS2C,
                (r,c,n) => new SyncSimTimeFinalS2C(r,c,n)
            },
            {
                GamePacketID.Waypoint_Acc,
                (r,c,n) => new Waypoint_Acc(r,c,n)
            },
            {
                GamePacketID.S2C_LockCamera,
                (r,c,n) => new S2C_LockCamera(r,c,n)
            },
            {
                GamePacketID.S2C_PlayVOAudioEvent,
                (r,c,n) => new S2C_PlayVOAudioEvent(r,c,n)
            },
            {
                GamePacketID.AI_Command,
                (r,c,n) => new AI_Command(r,c,n)
            },
            {
                GamePacketID.NPC_BuffRemove2,
                (r,c,n) => new NPC_BuffRemove2(r,c,n)
            },
            {
                GamePacketID.SpawnMinionS2C,
                (r,c,n) => new SpawnMinionS2C(r,c,n)
            },
            {
                GamePacketID.Unused125,
                (r,c,n) => new Unused125(r,c,n)
            },
            {
                GamePacketID.S2C_ToggleFoW,
                (r,c,n) => new S2C_ToggleFoW(r,c,n)
            },
            {
                GamePacketID.S2C_ToolTipVars,
                (r,c,n) => new S2C_ToolTipVars(r,c,n)
            },
            {
                GamePacketID.Unused128,
                (r,c,n) => new Unused128(r,c,n)
            },
            {
                GamePacketID.World_LockCamera_Server,
                (r,c,n) => new World_LockCamera_Server(r,c,n)
            },
            {
                GamePacketID.BuyItemReq,
                (r,c,n) => new BuyItemReq(r,c,n)
            },
            {
                GamePacketID.WaypointListHeroWithSpeed,
                (r,c,n) => new WaypointListHeroWithSpeed(r,c,n)
            },
            {
                GamePacketID.S2C_SetInputLockFlag,
                (r,c,n) => new S2C_SetInputLockFlag(r,c,n)
            },
            {
                GamePacketID.CHAR_SetCooldown,
                (r,c,n) => new CHAR_SetCooldown(r,c,n)
            },
            {
                GamePacketID.CHAR_CancelTargetingReticle,
                (r,c,n) => new CHAR_CancelTargetingReticle(r,c,n)
            },
            {
                GamePacketID.FX_Create_Group,
                (r,c,n) => new FX_Create_Group(r,c,n)
            },
            {
                GamePacketID.S2C_QueryStatusAns,
                (r,c,n) => new S2C_QueryStatusAns(r,c,n)
            },
            {
                GamePacketID.Building_Die,
                (r,c,n) => new Building_Die(r,c,n)
            },
            {
                GamePacketID.S2C_PreloadCharacterData,
                (r,c,n) => new S2C_PreloadCharacterData(r,c,n)
            },
            {
                GamePacketID.SPM_RemoveListener,
                (r,c,n) => new SPM_RemoveListener(r,c,n)
            },
            {
                GamePacketID.S2C_HandleQuestUpdate,
                (r,c,n) => new S2C_HandleQuestUpdate(r,c,n)
            },
            {
                GamePacketID.C2S_ClientFinished,
                (r,c,n) => new C2S_ClientFinished(r,c,n)
            },
            {
                GamePacketID.SPM_RemoveMemoryListener,
                (r,c,n) => new SPM_RemoveMemoryListener(r,c,n)
            },
            {
                GamePacketID.C2S_Exit,
                (r,c,n) => new C2S_Exit(r,c,n)
            },
            {
                GamePacketID.S2C_ModifyDebugObjectColor,
                (r,c,n) => new S2C_ModifyDebugObjectColor(r,c,n)
            },
            {
                GamePacketID.SPM_AddListener,
                (r,c,n) => new SPM_AddListener(r,c,n)
            },
            {
                GamePacketID.World_SendGameNumber,
                (r,c,n) => new World_SendGameNumber(r,c,n)
            },
            {
                GamePacketID.SetPARState,
                (r,c,n) => new SetPARState(r,c,n)
            },
            {
                GamePacketID.NPC_BuffRemoveGroup,
                (r,c,n) => new NPC_BuffRemoveGroup(r,c,n)
            },
            {
                GamePacketID.S2C_Ping_Load_Info,
                (r,c,n) => new S2C_Ping_Load_Info(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeCharacterVoice,
                (r,c,n) => new S2C_ChangeCharacterVoice(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeCharacterData,
                (r,c,n) => new S2C_ChangeCharacterData(r,c,n)
            },
            {
                GamePacketID.S2C_Exit,
                (r,c,n) => new S2C_Exit(r,c,n)
            },
            {
                GamePacketID.SPM_RemoveBBProfileListener,
                (r,c,n) => new SPM_RemoveBBProfileListener(r,c,n)
            },
            {
                GamePacketID.NPC_CastSpellReq,
                (r,c,n) => new NPC_CastSpellReq(r,c,n)
            },
            {
                GamePacketID.S2C_ToggleInputLockFlag,
                (r,c,n) => new S2C_ToggleInputLockFlag(r,c,n)
            },
            {
                GamePacketID.C2S_SoftReconnect,
                (r,c,n) => new C2S_SoftReconnect(r,c,n)
            },
            {
                GamePacketID.S2C_CreateTurret,
                (r,c,n) => new S2C_CreateTurret(r,c,n)
            },
            {
                GamePacketID.NPC_Die_Broadcast,
                (r,c,n) => new NPC_Die_Broadcast(r,c,n)
            },
            {
                GamePacketID.UseItemAns,
                (r,c,n) => new UseItemAns(r,c,n)
            },
            {
                GamePacketID.S2C_ShowAuxiliaryText,
                (r,c,n) => new S2C_ShowAuxiliaryText(r,c,n)
            },
            {
                GamePacketID.PausePacket,
                (r,c,n) => new PausePacket(r,c,n)
            },
            {
                GamePacketID.S2C_HideObjectiveText,
                (r,c,n) => new S2C_HideObjectiveText(r,c,n)
            },
            {
                GamePacketID.OnEvent,
                (r,c,n) => new OnEvent(r,c,n)
            },
            {
                GamePacketID.C2S_TeamSurrenderVote,
                (r,c,n) => new C2S_TeamSurrenderVote(r,c,n)
            },
            {
                GamePacketID.S2C_TeamSurrenderStatus,
                (r,c,n) => new S2C_TeamSurrenderStatus(r,c,n)
            },
            {
                GamePacketID.SPM_AddBBProfileListener,
                (r,c,n) => new SPM_AddBBProfileListener(r,c,n)
            },
            {
                GamePacketID.S2C_HideAuxiliaryText,
                (r,c,n) => new S2C_HideAuxiliaryText(r,c,n)
            },
            {
                GamePacketID.OnReplication_Acc,
                (r,c,n) => new OnReplication_Acc(r,c,n)
            },
            {
                GamePacketID.S2C_SetGreyscaleEnabledWhenDead,
                (r,c,n) => new S2C_SetGreyscaleEnabledWhenDead(r,c,n)
            },
            {
                GamePacketID.S2C_AI_State,
                (r,c,n) => new S2C_AI_State(r,c,n)
            },
            {
                GamePacketID.S2C_SetFoWStatus,
                (r,c,n) => new S2C_SetFoWStatus(r,c,n)
            },
            {
                GamePacketID.ReloadScripts,
                (r,c,n) => new ReloadScripts(r,c,n)
            },
            {
                GamePacketID.Cheat,
                (r,c,n) => new Cheat(r,c,n)
            },
            {
                GamePacketID.OnEnterLocalVisiblityClient,
                (r,c,n) => new OnEnterLocalVisiblityClient(r,c,n)
            },
            {
                GamePacketID.SendSelectedObjID,
                (r,c,n) => new SendSelectedObjID(r,c,n)
            },
            {
                GamePacketID.S2C_PlayAnimation,
                (r,c,n) => new S2C_PlayAnimation(r,c,n)
            },
            {
                GamePacketID.S2C_RefreshAuxiliaryText,
                (r,c,n) => new S2C_RefreshAuxiliaryText(r,c,n)
            },
            {
                GamePacketID.SetFadeOut_Push,
                (r,c,n) => new SetFadeOut_Push(r,c,n)
            },
            {
                GamePacketID.S2C_OpenTutorialPopup,
                (r,c,n) => new S2C_OpenTutorialPopup(r,c,n)
            },
            {
                GamePacketID.S2C_RemoveUnitHighlight,
                (r,c,n) => new S2C_RemoveUnitHighlight(r,c,n)
            },
            {
                GamePacketID.NPC_CastSpellAns,
                (r,c,n) => new NPC_CastSpellAns(r,c,n)
            },
            {
                GamePacketID.SPM_HierarchicalBBProfileUpdate,
                (r,c,n) => new SPM_HierarchicalBBProfileUpdate(r,c,n)
            },
            {
                GamePacketID.NPC_BuffAdd2,
                (r,c,n) => new NPC_BuffAdd2(r,c,n)
            },
            {
                GamePacketID.S2C_OpenAFKWarningMessage,
                (r,c,n) => new S2C_OpenAFKWarningMessage(r,c,n)
            },
            {
                GamePacketID.WaypointList,
                (r,c,n) => new WaypointList(r,c,n)
            },
            {
                GamePacketID.OnEnterVisiblityClient,
                (r,c,n) => new OnEnterVisiblityClient(r,c,n)
            },
            {
                GamePacketID.S2C_AddDebugObject,
                (r,c,n) => new S2C_AddDebugObject(r,c,n)
            },
            {
                GamePacketID.S2C_DisableHUDForEndOfGame,
                (r,c,n) => new S2C_DisableHUDForEndOfGame(r,c,n)
            },
            {
                GamePacketID.SynchVersionC2S,
                (r,c,n) => new SynchVersionC2S(r,c,n)
            },
            {
                GamePacketID.C2S_CharSelected,
                (r,c,n) => new C2S_CharSelected(r,c,n)
            },
            {
                GamePacketID.NPC_BuffUpdateCountGroup,
                (r,c,n) => new NPC_BuffUpdateCountGroup(r,c,n)
            },
            {
                GamePacketID.AI_TargetHeroS2C,
                (r,c,n) => new AI_TargetHeroS2C(r,c,n)
            },
            {
                GamePacketID.SynchSimTimeS2C,
                (r,c,n) => new SynchSimTimeS2C(r,c,n)
            },
            {
                GamePacketID.SyncMissionStartTimeS2C,
                (r,c,n) => new SyncMissionStartTimeS2C(r,c,n)
            },
            {
                GamePacketID.S2C_Neutral_Camp_Empty,
                (r,c,n) => new S2C_Neutral_Camp_Empty(r,c,n)
            },
            {
                GamePacketID.OnReplication,
                (r,c,n) => new OnReplication(r,c,n)
            },
            {
                GamePacketID.S2C_EndOfGameEvent,
                (r,c,n) => new S2C_EndOfGameEvent(r,c,n)
            },
            {
                GamePacketID.S2C_EndGame,
                (r,c,n) => new S2C_EndGame(r,c,n)
            },
            {
                GamePacketID.SPM_SamplingProfilerUpdate,
                (r,c,n) => new SPM_SamplingProfilerUpdate(r,c,n)
            },
            {
                GamePacketID.S2C_PopAllCharacterData,
                (r,c,n) => new S2C_PopAllCharacterData(r,c,n)
            },
            {
                GamePacketID.S2C_TeamSurrenderVote,
                (r,c,n) => new S2C_TeamSurrenderVote(r,c,n)
            },
            {
                GamePacketID.S2C_HandleUIHighlight,
                (r,c,n) => new S2C_HandleUIHighlight(r,c,n)
            },
            {
                GamePacketID.S2C_FadeMinions,
                (r,c,n) => new S2C_FadeMinions(r,c,n)
            },
            {
                GamePacketID.C2S_OnTutorialPopupClosed,
                (r,c,n) => new C2S_OnTutorialPopupClosed(r,c,n)
            },
            {
                GamePacketID.C2S_OnQuestEvent,
                (r,c,n) => new C2S_OnQuestEvent(r,c,n)
            },
            {
                GamePacketID.S2C_ShowHealthBar,
                (r,c,n) => new S2C_ShowHealthBar(r,c,n)
            },
            {
                GamePacketID.SpawnBotS2C,
                (r,c,n) => new SpawnBotS2C(r,c,n)
            },
            {
                GamePacketID.SpawnLevelPropS2C,
                (r,c,n) => new SpawnLevelPropS2C(r,c,n)
            },
            {
                GamePacketID.UpdateLevelPropS2C,
                (r,c,n) => new UpdateLevelPropS2C(r,c,n)
            },
            {
                GamePacketID.AttachFlexParticleS2C,
                (r,c,n) => new AttachFlexParticleS2C(r,c,n)
            },
            {
                GamePacketID.S2C_HandleCapturePointUpdate,
                (r,c,n) => new S2C_HandleCapturePointUpdate(r,c,n)
            },
            {
                GamePacketID.S2C_HandleGameScore,
                (r,c,n) => new S2C_HandleGameScore(r,c,n)
            },
            {
                GamePacketID.S2C_HandleRespawnPointUpdate,
                (r,c,n) => new S2C_HandleRespawnPointUpdate(r,c,n)
            },
            {
                GamePacketID.C2S_OnRespawnPointEvent,
                (r,c,n) => new C2S_OnRespawnPointEvent(r,c,n)
            },
            {
                GamePacketID.S2C_UnitChangeTeam,
                (r,c,n) => new S2C_UnitChangeTeam(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetMinimapIcon,
                (r,c,n) => new S2C_UnitSetMinimapIcon(r,c,n)
            },
            {
                GamePacketID.S2C_IncrementPlayerScore,
                (r,c,n) => new S2C_IncrementPlayerScore(r,c,n)
            },
            {
                GamePacketID.S2C_IncrementPlayerStat,
                (r,c,n) => new S2C_IncrementPlayerStat(r,c,n)
            },
            {
                GamePacketID.S2C_ColorRemapFX,
                (r,c,n) => new S2C_ColorRemapFX(r,c,n)
            },
            {
                GamePacketID.S2C_InteractiveMusicCommand,
                (r,c,n) => new S2C_InteractiveMusicCommand(r,c,n)
            },
            {
                GamePacketID.Unused221,
                (r,c,n) => new Unused221(r,c,n)
            },
            {
                GamePacketID.Unused222,
                (r,c,n) => new Unused222(r,c,n)
            },
            {
                GamePacketID.Unused223,
                (r,c,n) => new Unused223(r,c,n)
            },
            {
                GamePacketID.S2C_OnEnterTeamVisiblity,
                (r,c,n) => new S2C_OnEnterTeamVisiblity(r,c,n)
            },
            {
                GamePacketID.S2C_OnLeaveTeamVisiblity,
                (r,c,n) => new S2C_OnLeaveTeamVisiblity(r,c,n)
            },
            {
                GamePacketID.S2C_FX_OnEnterTeamVisiblity,
                (r,c,n) => new S2C_FX_OnEnterTeamVisiblity(r,c,n)
            },
            {
                GamePacketID.S2C_FX_OnLeaveTeamVisiblity,
                (r,c,n) => new S2C_FX_OnLeaveTeamVisiblity(r,c,n)
            },
            {
                GamePacketID.ReplayOnly_GoldEarned,
                (r,c,n) => new ReplayOnly_GoldEarned(r,c,n)
            },
            {
                GamePacketID.S2C_CloseClient,
                (r,c,n) => new S2C_CloseClient(r,c,n)
            },
            {
                GamePacketID.C2S_SpellChargeUpdateReq,
                (r,c,n) => new C2S_SpellChargeUpdateReq(r,c,n)
            },
            {
                GamePacketID.S2C_ModifyDebugText,
                (r,c,n) => new S2C_ModifyDebugText(r,c,n)
            },
            {
                GamePacketID.S2C_SetDebugHidden,
                (r,c,n) => new S2C_SetDebugHidden(r,c,n)
            },
            {
                GamePacketID.S2C_ActivateMinionCamp,
                (r,c,n) => new S2C_ActivateMinionCamp(r,c,n)
            },
            {
                GamePacketID.C2S_SpectatorDataReq,
                (r,c,n) => new C2S_SpectatorDataReq(r,c,n)
            },
            {
                GamePacketID.S2C_SpectatorMetaData,
                (r,c,n) => new S2C_SpectatorMetaData(r,c,n)
            },
            {
                GamePacketID.S2C_SpectatorDataChunkInfo,
                (r,c,n) => new S2C_SpectatorDataChunkInfo(r,c,n)
            },
            {
                GamePacketID.S2C_SpectatorDataChunk,
                (r,c,n) => new S2C_SpectatorDataChunk(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeMissileTarget,
                (r,c,n) => new S2C_ChangeMissileTarget(r,c,n)
            },
            {
                GamePacketID.S2C_MarkOrSweepForSoftReconnect,
                (r,c,n) => new S2C_MarkOrSweepForSoftReconnect(r,c,n)
            },
            {
                GamePacketID.S2C_SetShopEnabled,
                (r,c,n) => new S2C_SetShopEnabled(r,c,n)
            },
            {
                GamePacketID.S2C_CreateFollowerObject,
                (r,c,n) => new S2C_CreateFollowerObject(r,c,n)
            },
            {
                GamePacketID.S2C_ReattachFollowerObject,
                (r,c,n) => new S2C_ReattachFollowerObject(r,c,n)
            },
            {
                GamePacketID.S2C_PlayContextualEmote,
                (r,c,n) => new S2C_PlayContextualEmote(r,c,n)
            },
            {
                GamePacketID.C2S_PlayContextualEmote,
                (r,c,n) => new C2S_PlayContextualEmote(r,c,n)
            },
            {
                GamePacketID.S2C_SetHoverIndicatorTarget,
                (r,c,n) => new S2C_SetHoverIndicatorTarget(r,c,n)
            },
            {
                GamePacketID.S2C_SetHoverIndicatorEnabled,
                (r,c,n) => new S2C_SetHoverIndicatorEnabled(r,c,n)
            },
            {
                GamePacketID.S2C_SystemMessage,
                (r,c,n) => new S2C_SystemMessage(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeEmitterGroup,
                (r,c,n) => new S2C_ChangeEmitterGroup(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateRestrictedChatCount,
                (r,c,n) => new S2C_UpdateRestrictedChatCount(r,c,n)
            },
            {
                GamePacketID.S2C_TeamBalanceVote,
                (r,c,n) => new S2C_TeamBalanceVote(r,c,n)
            },
            {
                GamePacketID.C2S_TeamBalanceVote,
                (r,c,n) => new C2S_TeamBalanceVote(r,c,n)
            },
            {
                GamePacketID.S2C_TeamBalanceStatus,
                (r,c,n) => new S2C_TeamBalanceStatus(r,c,n)
            },
            {
                GamePacketID.S2C_SetItemCharges,
                (r,c,n) => new S2C_SetItemCharges(r,c,n)
            },
            /*
            {
                GamePacketID.Batched,
                (r,c,n) => new Batched(r,c,n)
            },
            */
            {
                GamePacketID.SpawnMarkerS2C,
                (r,c,n) => new SpawnMarkerS2C(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetAutoAttackGroundAllowed,
                (r,c,n) => new S2C_UnitSetAutoAttackGroundAllowed(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetShowAutoAttackIndicator,
                (r,c,n) => new S2C_UnitSetShowAutoAttackIndicator(r,c,n)
            },
            {
                GamePacketID.S2C_AnimationUpdateTimeStep,
                (r,c,n) => new S2C_AnimationUpdateTimeStep(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetSpellPARCost,
                (r,c,n) => new S2C_UnitSetSpellPARCost(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetDrawPathMode,
                (r,c,n) => new S2C_UnitSetDrawPathMode(r,c,n)
            },
            {
                GamePacketID.C2S_UnitSendDrawPath,
                (r,c,n) => new C2S_UnitSendDrawPath(r,c,n)
            },
            {
                GamePacketID.S2C_AmmoUpdate,
                (r,c,n) => new S2C_AmmoUpdate(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetCursorReticle,
                (r,c,n) => new S2C_UnitSetCursorReticle(r,c,n)
            },
            {
                GamePacketID.NPC_BuffUpdateNumCounter,
                (r,c,n) => new NPC_BuffUpdateNumCounter(r,c,n)
            },
            {
                GamePacketID.C2S_UndoItemReq,
                (r,c,n) => new C2S_UndoItemReq(r,c,n)
            },
            {
                GamePacketID.S2C_SetUndoEnabled,
                (r,c,n) => new S2C_SetUndoEnabled(r,c,n)
            },
            {
                GamePacketID.S2C_SetInventory_Broadcast,
                (r,c,n) => new S2C_SetInventory_Broadcast(r,c,n)
            },
            {
                GamePacketID.S2C_ChangeMissileSpeed,
                (r,c,n) => new S2C_ChangeMissileSpeed(r,c,n)
            },
            {
                GamePacketID.S2C_SetCanSurrender,
                (r,c,n) => new S2C_SetCanSurrender(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetLookAt,
                (r,c,n) => new S2C_UnitSetLookAt(r,c,n)
            },
            {
                GamePacketID.S2C_DestroyUnit,
                (r,c,n) => new S2C_DestroyUnit(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetSpellLevelOverrides,
                (r,c,n) => new S2C_UnitSetSpellLevelOverrides(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetMaxLevelOverride,
                (r,c,n) => new S2C_UnitSetMaxLevelOverride(r,c,n)
            },
            {
                GamePacketID.S2C_UnitSetPARType,
                (r,c,n) => new S2C_UnitSetPARType(r,c,n)
            },
            {
                GamePacketID.S2C_MoveMarker,
                (r,c,n) => new S2C_MoveMarker(r,c,n)
            },
            {
                GamePacketID.ReplayOnly_MultiKillCountUpdate,
                (r,c,n) => new ReplayOnly_MultiKillCountUpdate(r,c,n)
            },
            {
                GamePacketID.S2C_NeutralMinionTimerUpdate,
                (r,c,n) => new S2C_NeutralMinionTimerUpdate(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateDeathTimer,
                (r,c,n) => new S2C_UpdateDeathTimer(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateSpellToggle,
                (r,c,n) => new S2C_UpdateSpellToggle(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateBounceMissile,
                (r,c,n) => new S2C_UpdateBounceMissile(r,c,n)
            },
            {
                GamePacketID.S2C_DebugLogGoldSources,
                (r,c,n) => new S2C_DebugLogGoldSources(r,c,n)
            },
            {
                GamePacketID.C2S_CheatLogGoldSources,
                (r,c,n) => new C2S_CheatLogGoldSources(r,c,n)
            },
            {
                GamePacketID.S2C_ShopItemSubstitutionSet,
                (r,c,n) => new S2C_ShopItemSubstitutionSet(r,c,n)
            },
            {
                GamePacketID.S2C_ShopItemSubstitutionClear,
                (r,c,n) => new S2C_ShopItemSubstitutionClear(r,c,n)
            },
            {
                GamePacketID.S2C_ResetClient,
                (r,c,n) => new S2C_ResetClient(r,c,n)
            },
            {
                GamePacketID.S2C_IncrementMinionKills,
                (r,c,n) => new S2C_IncrementMinionKills(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateAttackSpeedCapOverrides,
                (r,c,n) => new S2C_UpdateAttackSpeedCapOverrides(r,c,n)
            },
            {
                GamePacketID.S2C_NotifyContextualSituation,
                (r,c,n) => new S2C_NotifyContextualSituation(r,c,n)
            },
            {
                GamePacketID.S2C_CreateMinionCamp,
                (r,c,n) => new S2C_CreateMinionCamp(r,c,n)
            },
            {
                GamePacketID.S2C_SpawnTurret,
                (r,c,n) => new S2C_SpawnTurret(r,c,n)
            },
            {
                GamePacketID.S2C_UpdateAscended,
                (r,c,n) => new S2C_UpdateAscended(r,c,n)
            },
            {
                GamePacketID.ChangeSlotSpellData_OwnerOnly,
                (r,c,n) => new ChangeSlotSpellData_OwnerOnly(r,c,n)
            },
            {
                GamePacketID.S2C_NPC_Die_MapView,
                (r,c,n) => new S2C_NPC_Die_MapView(r,c,n)
            },
            {
                GamePacketID.S2C_SetInventory_MapView,
                (r,c,n) => new S2C_SetInventory_MapView(r,c,n)
            },
            {
                GamePacketID.NPC_MessageToClient_MapView,
                (r,c,n) => new NPC_MessageToClient_MapView(r,c,n)
            },
            {
                GamePacketID.S2C_StartSpellTargeter,
                (r,c,n) => new S2C_StartSpellTargeter(r,c,n)
            },
            {
                GamePacketID.S2C_StopSpellTargeter,
                (r,c,n) => new S2C_StopSpellTargeter(r,c,n)
            },
            {
                GamePacketID.S2C_CameraLock,
                (r,c,n) => new S2C_CameraLock(r,c,n)
            },
            {
                GamePacketID.UNK_0x12C,
                (r,c,n) => new UNK_0x12C(r,c,n)
            },
            {
                GamePacketID.S2C_SetFadeOut,
                (r,c,n) => new S2C_SetFadeOut(r,c,n)
            },
            {
                GamePacketID.UNK_0x12E_AddRegion,
                (r,c,n) => new UNK_0x12E_AddRegion(r,c,n)
            },
            {
                GamePacketID.S2C_UnlockAnimation,
                (r,c,n) => new S2C_UnlockAnimation(r,c,n)
            },
        };
    }
}
