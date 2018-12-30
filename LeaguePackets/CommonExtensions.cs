using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public static class CommonExtensions
    {
        public static void WriteNetID(this PacketWriter writer, NetID netID)
        {
            writer.WriteUInt32((uint)netID);
        }

        public static NetID ReadNetID(this PacketReader reader)
        {
            return (NetID)reader.ReadUInt32();
        }

        public static void WriteClientID(this PacketWriter writer, ClientID clientId)
        {
            writer.WriteUInt32((uint)clientId);
        }

        public static ClientID ReadClientID(this PacketReader reader)
        {
            return (ClientID)reader.ReadUInt32();
        }

        public static void WritePlayerID(this PacketWriter writer, PlayerID clientId)
        {
            writer.WriteUInt64((uint)clientId);
        }

        public static PlayerID ReadPlayerID(this PacketReader reader)
        {
            return (PlayerID)reader.ReadUInt64();
        }

        public static void WriteNetNodeID(this PacketWriter writer, NetNodeID nodeID)
        {
            writer.WriteByte((byte)nodeID);
        }

        public static NetNodeID ReadNetNodeID(this PacketReader reader)
        {
            return (NetNodeID)(reader.ReadByte());
        }

        public static void WriteNetTeam(this PacketWriter writer, NetTeam temaId)
        {
            writer.WriteUInt32((uint)temaId);
        }

        public static NetTeam ReadNetTeam(this PacketReader reader)
        {
            return (NetTeam)(reader.ReadUInt32());
        }

        public static ChatType ReadChatType(this PacketReader reader)
        {
            return (ChatType)(reader.ReadUInt32());
        }

        public static void WriteChatType(this PacketWriter writer, ChatType chatType)
        {
            writer.WriteUInt32((uint)chatType);
        }


        public static void WriteTeamID(this PacketWriter writer, TeamID temaId)
        {
            writer.WriteUInt32((uint)temaId);
        }

        public static TeamID ReadTeamID(this PacketReader reader)
        {
            return (TeamID)(reader.ReadUInt32());
        }

        public static DamageType ReadDamageType(this PacketReader reader)
        {
            return (DamageType)(reader.ReadUInt32());
        }

        public static void WriteDamageType(this PacketWriter writer, DamageType type)
        {
            writer.WriteUInt32((uint)type);
        }

        public static DamageSource ReadDamageSource(this PacketReader reader)
        {
            return (DamageSource)(reader.ReadUInt32());
        }

        public static void WriteDamageSource(this PacketWriter writer, DamageSource type)
        {
            writer.WriteUInt32((uint)type);
        }

        public static MinionRoamState ReadMinionRoamState(this PacketReader reader)
        {
            return (MinionRoamState)(reader.ReadUInt32());
        }

        public static void WriteMinionRoamState(this PacketWriter writer, MinionRoamState data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static BuffType ReadBuffType(this PacketReader reader)
        {
            return (BuffType)(reader.ReadByte());
        }

        public static void WriteBuffType(this PacketWriter writer, BuffType data)
        {
            writer.WriteByte((byte)data);
        }

        public static Color ReadColor(this PacketReader reader)
        {
            return (Color)reader.ReadUInt32();
        }

        public static void WriteColor(this PacketWriter writer, Color data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static AudioEventID ReadAudioEventID(this PacketReader reader)
        {
            return (AudioEventID)reader.ReadUInt32();
        }

        public static void WriteAudioEventID(this PacketWriter writer,AudioEventID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static MusicCommand ReadMusicCommand(this PacketReader reader)
        {
            return (MusicCommand)(reader.ReadByte());
        }

        public static void WriteMusicCommand(this PacketWriter writer, MusicCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static GroundAttackMode ReadGroundAttackMode(this PacketReader reader)
        {
            return (GroundAttackMode)(reader.ReadByte());
        }

        public static void WriteGroundAttackMode(this PacketWriter writer, GroundAttackMode data)
        {
            writer.WriteByte((byte)data);
        }

        public static EmoteID ReadEmoteID(this PacketReader reader)
        {
            return (EmoteID)(reader.ReadByte());
        }

        public static void WriteEmoteID(this PacketWriter writer, EmoteID data)
        {
            writer.WriteByte((byte)data);
        }

        public static VolumeCategoryType ReadVolumeCategoryType(this PacketReader reader)
        {
            return (VolumeCategoryType)(reader.ReadByte());
        }

        public static void WriteVolumeCategoryType(this PacketWriter writer, VolumeCategoryType data)
        {
            writer.WriteByte((byte)data);
        }

        public static SpellFlags ReadSpellFlags(this PacketReader reader)
        {
            return (SpellFlags)(reader.ReadUInt32());
        }

        public static void WriteSpellFlags (this PacketWriter writer, SpellFlags data)
        {
            writer.WriteUInt32((uint)data);
        }


        public static FloatTextType ReadFloatTextType(this PacketReader reader)
        {
            return (FloatTextType)(reader.ReadUInt32());
        }

        public static void WriteFloatTextType(this PacketWriter writer, FloatTextType data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static AudioVOEventType ReadAudioVOEventType(this PacketReader reader)
        {
            return (AudioVOEventType)(reader.ReadByte());
        }

        public static void WriteAudioVOEventType(this PacketWriter writer, AudioVOEventType data)
        {
            writer.WriteByte((byte)data);
        }

        public static SurrenderReason ReadSurrenderReason(this PacketReader reader)
        {
            return (SurrenderReason)(reader.ReadByte());
        }

        public static void WriteSurrenderReason (this PacketWriter writer, SurrenderReason data)
        {
            writer.WriteByte((byte)data);
        }

        public static UIElement ReadUIElement(this PacketReader reader)
        {
            return (UIElement)(reader.ReadByte());
        }

        public static void WriteUIElement(this PacketWriter writer, UIElement data)
        {
            writer.WriteByte((byte)data);
        }

        public static UIHighlightCommand ReadUIHighlightCommand(this PacketReader reader)
        {
            return (UIHighlightCommand)(reader.ReadByte());
        }

        public static void WriteUIHighlightCommand(this PacketWriter writer, UIHighlightCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static RespawnPointCommand ReadRespawnPointCommand(this PacketReader reader)
        {
            return (RespawnPointCommand)(reader.ReadByte());
        }

        public static void WriteRespawnPointCommand(this PacketWriter writer, RespawnPointCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static RespawnPointUIID ReadRespawnPointUIID(this PacketReader reader)
        {
            return (RespawnPointUIID)reader.ReadByte();
        }

        public static void WriteRespawnPointUIID(this PacketWriter writer, RespawnPointUIID data)
        {
            writer.WriteByte((byte)data);
        }

        public static RespawnPointEvent ReadRespawnPointEvent(this PacketReader reader)
        {
            return (RespawnPointEvent)(reader.ReadByte());
        }

        public static void WriteRespawnPointEvent(this PacketWriter writer, RespawnPointEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static ItemID ReadItemID(this PacketReader reader)
        {
            return (ItemID)reader.ReadUInt32();
        }

        public static void WriteItemID(this PacketWriter writer, ItemID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static PARType ReadPARType(this PacketReader reader)
        {
            return (PARType)(reader.ReadByte());
        }

        public static void WritePARType(this PacketWriter writer, PARType data)
        {
            writer.WriteByte((byte)data);
        }

        public static CostType ReadCostType(this PacketReader reader)
        {
            return (CostType)(reader.ReadByte());
        }

        public static void WriteCostType(this PacketWriter writer, CostType data)
        {
            writer.WriteByte((byte)data);
        }

        public static LookAtType ReadLookAtType(this PacketReader reader)
        {
            return (LookAtType)(reader.ReadByte());
        }

        public static void WriteLookAtType(this PacketWriter writer, LookAtType data)
        {
            writer.WriteByte((byte)data);
        }

        public static DrawPathNodeType ReadDrawPathNodeType(this PacketReader reader)
        {
            return (DrawPathNodeType)(reader.ReadByte());
        }

        public static void WriteDrawPathNodeType(this PacketWriter writer, DrawPathNodeType data)
        {
            writer.WriteByte((byte)data);
        }

        public static DrawPathMode ReadDrawPathMode(this PacketReader reader)
        {
            return (DrawPathMode)(reader.ReadByte());
        }

        public static void WriteDrawPathMode(this PacketWriter writer, DrawPathMode data)
        {
            writer.WriteByte((byte)data);
        }

        public static ContextualEmoteID ReadContextualEmoteID(this PacketReader reader)
        {
            return (ContextualEmoteID)(reader.ReadByte());
        }

        public static void WriteContextualEmoteID(this PacketWriter writer, ContextualEmoteID data)
        {
            writer.WriteByte((byte)data);
        }

        public static ContextualEmoteFlags ReadContextualEmoteFlags(this PacketReader reader)
        {
            return (ContextualEmoteFlags)(reader.ReadByte());
        }

        public static void WriteContextualEmoteFlags(this PacketWriter writer, ContextualEmoteFlags data)
        {
            writer.WriteByte((byte)data);
        }

        public static AudioVOComponentEvent ReadAudioVOComponentEvent(this PacketReader reader)
        {
            return (AudioVOComponentEvent)(reader.ReadByte());
        }

        public static void WriteAudioVOComponentEvent(this PacketWriter writer, AudioVOComponentEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static VisibilityTeam ReadVisibilityTeam(this PacketReader reader)
        {
            return (VisibilityTeam)(reader.ReadByte());
        }

        public static void WriteVisibilityTeam(this PacketWriter writer, VisibilityTeam data)
        {
            writer.WriteByte((byte)data);
        }

        public static StatEvent ReadStatEvent(this PacketReader reader)
        {
            return (StatEvent)(reader.ReadByte());
        }

        public static void WriteStatEvent(this PacketWriter writer, StatEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static ScoreEvent ReadScoreEvent(this PacketReader reader)
        {
            return (ScoreEvent)(reader.ReadByte());
        }

        public static void WriteScoreEvent(this PacketWriter writer, ScoreEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static ScoreCategory ReadScoreCategory(this PacketReader reader)
        {
            return (ScoreCategory)(reader.ReadByte());
        }

        public static void WriteScoreCategory(this PacketWriter writer, ScoreCategory data)
        {
            writer.WriteByte((byte)data);
        }

        public static CapturePointUpdateCommand ReadCapturePointUpdateCommand(this PacketReader reader)
        {
            return (CapturePointUpdateCommand)(reader.ReadByte());
        }

        public static void WriteCapturePointUpdateCommand(this PacketWriter writer, CapturePointUpdateCommand data)
        {
            writer.WriteByte((byte)data);
        }


        public static InputLockFlags ReadInputLockFlags(this PacketReader reader)
        {
            return (InputLockFlags)(reader.ReadUInt32());
        }

        public static void WriteInputLockFlags(this PacketWriter writer, InputLockFlags data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static QuestEvent ReadQuestEvent(this PacketReader reader)
        {
            return (QuestEvent)(reader.ReadByte());
        }

        public static void WriteQuestEvent(this PacketWriter writer, QuestEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static QuestID ReadQuestID(this PacketReader reader)
        {
            return (QuestID)reader.ReadUInt32();
        }

        public static void WriteQuestID(this PacketWriter writer, QuestID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static QuestCommand ReadQuestCommand(this PacketReader reader)
        {
            return (QuestCommand)(reader.ReadByte());
        }

        public static void WriteQuestCommand(this PacketWriter writer, QuestCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static QuestType ReadQuestType(this PacketReader reader)
        {
            return (QuestType)(reader.ReadByte());
        }

        public static void WriteQuestType(this PacketWriter writer, QuestType data)
        {
            writer.WriteByte((byte)data);
        }

        public static ParticleFlexID ReadFlexID(this PacketReader reader)
        {
            return (ParticleFlexID)reader.ReadByte();
        }

        public static void WriteFlexID(this PacketWriter writer, ParticleFlexID data)
        {
            writer.WriteByte((byte)data);
        }

        public static AIState ReadAIState(this PacketReader reader)
        {
            return (AIState)(reader.ReadUInt32());
        }

        public static void WriteAIState(this PacketWriter writer, AIState data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static AnimationFlags ReadAnimationFlags(this PacketReader reader)
        {
            return (AnimationFlags)(reader.ReadUInt32());
        }

        public static void WriteAnimationFlags(this PacketWriter writer, AnimationFlags data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static ParticleAttachType ReadParticleAttachType(this PacketReader reader)
        {
            return (ParticleAttachType)(reader.ReadByte());
        }

        public static void WriteParticleAttachType(this PacketWriter writer, ParticleAttachType data)
        {
            writer.WriteByte((byte)data);
        }

        public static PARState ReadPARState(this PacketReader reader)
        {
            return (PARState)(reader.ReadUInt32());
        }

        public static void WritePARState(this PacketWriter writer, PARState data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static MusicID ReadMusicID(this PacketReader reader)
        {
            return (MusicID)reader.ReadUInt32();
        }

        public static void WriteMusicID(this PacketWriter writer, MusicID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static TipCommand ReadTipCommand(this PacketReader reader)
        {
            return (TipCommand)(reader.ReadByte());
        }

        public static void WriteTipCommand(this PacketWriter writer, TipCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static TipID ReadTipID(this PacketReader reader)
        {
            return (TipID)reader.ReadUInt32();
        }

        public static void WriteTipID(this PacketWriter writer, TipID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static HealthBarType ReadHealthBarType(this PacketReader reader)
        {
            return (HealthBarType)(reader.ReadByte());
        }

        public static void WriteHealthBarType(this PacketWriter writer, HealthBarType data)
        {
            writer.WriteByte((byte)data);
        }

        public static GameFeatures ReadGameFeatures(this PacketReader reader)
        {
            return (GameFeatures)(reader.ReadUInt64());
        }

        public static void WriteGameFeatures(this PacketWriter writer, GameFeatures data)
        {
            writer.WriteUInt64((ulong)data);
        }

        public static TargetingType ReadTargetingType(this PacketReader reader)
        {
            return (TargetingType)(reader.ReadByte());
        }

        public static void WriteTargetingType(this PacketWriter writer, TargetingType data)
        {
            writer.WriteByte((byte)data);
        }

        public static SpectatorChunkType ReadSpectatorChunkType(this PacketReader reader)
        {
            return (SpectatorChunkType)(reader.ReadByte());
        }

        public static void WriteSpectatorChunkType(this PacketWriter writer, SpectatorChunkType data)
        {
            writer.WriteByte((byte)data);
        }

        public static OrderType ReadOrderType(this PacketReader reader)
        {
            return (OrderType)(reader.ReadByte());
        }

        public static void WriteOrderType(this PacketWriter writer, OrderType data)
        {
            writer.WriteByte((byte)data);
        }

        public static HitResult ReadHitResult(this PacketReader reader)
        {
            return (HitResult)(reader.ReadByte());
        }

        public static void WriteHitResult(this PacketWriter writer, HitResult data)
        {
            writer.WriteByte((byte)data);
        }

        public static EventSourceType ReadEventSourceType(this PacketReader reader)
        {
            return (EventSourceType)(reader.ReadByte());
        }

        public static void WriteEventSourceType(this PacketWriter writer, EventSourceType data)
        {
            writer.WriteByte((byte)data);
        }
    }
}
