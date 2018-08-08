using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public abstract class ChangeSlotSpellData : GamePacket // 0x17
    {
        public override GamePacketID ID => GamePacketID.ChangeSlotSpellData;
        public byte SpellSlot { get; set; }
        public bool IsSummonerSpell { get; set; }
        protected abstract ChangeSlotSpellDataType ChangeSlotSpellDataType { get; }
        protected abstract void ReadBodyInternal(PacketReader reader);
        protected abstract void WriteBodyInternal(PacketWriter writer);

        public static ChangeSlotSpellData CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            byte bitfield = reader.ReadByte();
            byte spellSlot = (byte)(bitfield & 0x3F);
            bool isSummonerSpell = (bitfield & 0x40) != 0;
            ChangeSlotSpellData data;
            ChangeSlotSpellDataType type = (ChangeSlotSpellDataType)reader.ReadByte();
            switch (type)
            {
                case ChangeSlotSpellDataType.TargetingType:
                    data = new ChangeSlotSpellDataTargetingType();
                    break;
                case ChangeSlotSpellDataType.SpellName:
                    data = new ChangeSlotSpellDataSpellName();
                    break;
                case ChangeSlotSpellDataType.Range:
                    data = new ChangeSlotSpellDataRange();
                    break;
                case ChangeSlotSpellDataType.MaxGrowthRange:
                    data = new ChangeSlotSpellDataMaxGrowthRange();
                    break;
                case ChangeSlotSpellDataType.RangeDisplay:
                    data = new ChangeSlotSpellDataRangeDisplay();
                    break;
                case ChangeSlotSpellDataType.IconIndex:
                    data = new ChangeSlotSpellDataIconIndex();
                    break;
                case ChangeSlotSpellDataType.OffsetTarget:
                    data = new ChangeSlotSpellDataOffsetTarget();
                    break;
                default:
                    data = new ChangeSlotSpellDataUnknown();
                    break;
            }
            data.SpellSlot = spellSlot;
            data.IsSummonerSpell = isSummonerSpell;
            data.ReadBodyInternal(reader);
            return data;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)((byte)SpellSlot & 0x3F);
            if (IsSummonerSpell)
                bitfield |= 0x40;
            writer.WriteByte((byte)ChangeSlotSpellDataType);
            WriteBodyInternal(writer);
        }
    }

    public class ChangeSlotSpellDataUnknown : ChangeSlotSpellData
    {
        private ChangeSlotSpellDataType _changeSlotSpellDataType;
        public ChangeSlotSpellDataUnknown() {}
        public ChangeSlotSpellDataUnknown(ChangeSlotSpellDataType type) => _changeSlotSpellDataType = type;
        public ChangeSlotSpellDataType ChangeSlotSpellDataTypeRaw
        {
            get => _changeSlotSpellDataType;
            set => _changeSlotSpellDataType = value;
        }
        protected override ChangeSlotSpellDataType ChangeSlotSpellDataType => _changeSlotSpellDataType;
        protected override void ReadBodyInternal(PacketReader reader) { }
        protected override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class ChangeSlotSpellDataTargetingType : ChangeSlotSpellData
    {
        protected override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.TargetingType;
        public TargetingType TargetingType { get; set; }
        protected override void ReadBodyInternal(PacketReader reader)
        {
            TargetingType = reader.ReadTargetingType();
        }
        protected override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteTargetingType(TargetingType);
        }
    }

    public class ChangeSlotSpellDataSpellName : ChangeSlotSpellData
    {
        protected override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.SpellName;
        public string SpellName { get; set; } = "";
        protected override void ReadBodyInternal(PacketReader reader)
        {
            SpellName = reader.ReadZeroTerminatedString();
        }
        protected override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteZeroTerminatedString(SpellName);
        }
    }

    public class ChangeSlotSpellDataRange : ChangeSlotSpellData
    {
        protected override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.Range;
        public float CastRange { get; set; }
        protected override void ReadBodyInternal(PacketReader reader)
        {
            CastRange = reader.ReadFloat();
        }
        protected override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(CastRange);
        }
    }

    public class ChangeSlotSpellDataMaxGrowthRange : ChangeSlotSpellData
    {
        protected override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.MaxGrowthRange;
        public float OverrideMaxCastRange { get; set; }
        protected override void ReadBodyInternal(PacketReader reader)
        {
            OverrideMaxCastRange = reader.ReadFloat();
        }
        protected override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(OverrideMaxCastRange);
        }
    }

    public class ChangeSlotSpellDataRangeDisplay : ChangeSlotSpellData
    {
        protected override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.RangeDisplay;
        public float OverrideCastRangeDisplay { get; set; }
        protected override void ReadBodyInternal(PacketReader reader)
        {
            OverrideCastRangeDisplay = reader.ReadFloat();
        }
        protected override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(OverrideCastRangeDisplay);
        }
    }

    public class ChangeSlotSpellDataIconIndex : ChangeSlotSpellData
    {
        protected override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.IconIndex;
        public byte IconIndex { get; set; }
        protected override void ReadBodyInternal(PacketReader reader)
        {
            IconIndex = reader.ReadByte();
        }
        protected override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteByte(IconIndex);
        }
    }

    public class ChangeSlotSpellDataOffsetTarget : ChangeSlotSpellData
    {
        protected override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.OffsetTarget;
        public List<NetID> Targets { get; set; } = new List<NetID>();
        protected override void ReadBodyInternal(PacketReader reader)
        {
            int count = reader.ReadByte();
            for (int i = 0; i < count; i++)
            {
                Targets.Add(reader.ReadNetID());
            }
        }
        protected override void WriteBodyInternal(PacketWriter writer)
        {
            var count = Targets.Count;
            if (count > 0xFF)
            {
                throw new IOException("Too many targets!");
            }
            writer.WriteByte((byte)count);
            for (var i = 0; i < count; i++)
            {
                writer.WriteNetID(Targets[i]);
            }
        }
    }
}
