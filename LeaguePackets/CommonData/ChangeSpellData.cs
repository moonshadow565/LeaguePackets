using System;
using System.Collections.Generic;
using System.IO;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public abstract class ChangeSpellData
    {
        public abstract ChangeSlotSpellDataType ChangeSlotSpellDataType { get; }
        public byte SpellSlot { get; set; }
        public bool IsSummonerSpell { get; set; }

        public abstract void ReadBodyInternal(PacketReader reader);
        public abstract void WriteBodyInternal(PacketWriter writer);
    }

    public static class ChangeSpellDataExtension
    {
        public static ChangeSpellData ReadChangeSpellData(this PacketReader reader)
        {
            ChangeSpellData data;

            byte spellSlot = reader.ReadByte();

            byte bitfield = reader.ReadByte();
            bool isSummonerSpell = (bitfield & 0x01) != 0;

            ChangeSlotSpellDataType type = (ChangeSlotSpellDataType)reader.ReadUInt32();
            switch (type)
            {
                case ChangeSlotSpellDataType.TargetingType:
                    data = new ChangeSpellDataTargetingType();
                    break;
                case ChangeSlotSpellDataType.SpellName:
                    data = new ChangeSpellDataSpellName();
                    break;
                case ChangeSlotSpellDataType.Range:
                    data = new ChangeSpellDataRange();
                    break;
                case ChangeSlotSpellDataType.MaxGrowthRange:
                    data = new ChangeSpellDataMaxGrowthRange();
                    break;
                case ChangeSlotSpellDataType.RangeDisplay:
                    data = new ChangeSpellDataRangeDisplay();
                    break;
                case ChangeSlotSpellDataType.IconIndex:
                    data = new ChangeSpellDataIconIndex();
                    break;
                case ChangeSlotSpellDataType.OffsetTarget:
                    data = new ChangeSpellDataOffsetTarget();
                    break;
                default:
                    data = new ChangeSpellDataUnknown();
                    break;
            }

            data.SpellSlot = spellSlot;
            data.IsSummonerSpell = isSummonerSpell;
            data.ReadBodyInternal(reader);
            return data;
        }
        public static void WriteChangeSpellData(this PacketWriter writer, ChangeSpellData data)
        {
            writer.WriteByte(data.SpellSlot);

            byte bitfield = 0;
            if (data.IsSummonerSpell)
                bitfield |= 0x01;

            writer.WriteByte(bitfield);
            writer.WriteUInt32((uint)data.ChangeSlotSpellDataType);
            data.WriteBodyInternal(writer);
        }
    }

    public class ChangeSpellDataUnknown : ChangeSpellData
    {
        private ChangeSlotSpellDataType _changeSlotSpellDataType;
        public ChangeSpellDataUnknown() { }
        public ChangeSpellDataUnknown(ChangeSlotSpellDataType type) => _changeSlotSpellDataType = type;
        public ChangeSlotSpellDataType  ChangeSlotSpellDataTypeRaw
        {
            get  => _changeSlotSpellDataType;
            set => _changeSlotSpellDataType = value;
        }
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => _changeSlotSpellDataType;
        public override void ReadBodyInternal(PacketReader reader) { }
        public override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class ChangeSpellDataTargetingType : ChangeSpellData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.TargetingType;
        public TargetingType TargetingType { get; set; }
        public override void ReadBodyInternal(PacketReader reader)
        {
            TargetingType = reader.ReadTargetingType();
        }
        public override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteTargetingType(TargetingType);
        }
    }

    public class ChangeSpellDataSpellName : ChangeSpellData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.SpellName;
        public string SpellName { get; set; } = "";
        public override void ReadBodyInternal(PacketReader reader)
        {
            SpellName = reader.ReadZeroTerminatedString();
        }
        public override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteZeroTerminatedString(SpellName);
        }
    }

    public class ChangeSpellDataRange : ChangeSpellData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.Range;
        public float CastRange { get; set; }
        public override void ReadBodyInternal(PacketReader reader)
        {
            CastRange = reader.ReadFloat();
        }
        public override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(CastRange);
        }
    }

    public class ChangeSpellDataMaxGrowthRange : ChangeSpellData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.MaxGrowthRange;
        public float OverrideMaxCastRange { get; set; }
        public override void ReadBodyInternal(PacketReader reader)
        {
            OverrideMaxCastRange = reader.ReadFloat();
        }
        public override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(OverrideMaxCastRange);
        }
    }

    public class ChangeSpellDataRangeDisplay : ChangeSpellData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.RangeDisplay;
        public float OverrideCastRangeDisplay { get; set; }
        public override void ReadBodyInternal(PacketReader reader)
        {
            OverrideCastRangeDisplay = reader.ReadFloat();
        }
        public override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(OverrideCastRangeDisplay);
        }
    }

    public class ChangeSpellDataIconIndex : ChangeSpellData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.IconIndex;
        public byte IconIndex { get; set; }
        public override void ReadBodyInternal(PacketReader reader)
        {
            IconIndex = reader.ReadByte();
        }
        public override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteByte(IconIndex);
        }
    }

    public class ChangeSpellDataOffsetTarget : ChangeSpellData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.OffsetTarget;
        public List<NetID> Targets { get; set; } = new List<NetID>();
        public override void ReadBodyInternal(PacketReader reader)
        {
            int count = reader.ReadByte();
            for (int i = 0; i < count; i++)
            {
                Targets.Add(reader.ReadNetID());
            }
        }
        public override void WriteBodyInternal(PacketWriter writer)
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
