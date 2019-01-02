using System;
using System.Collections.Generic;
using System.IO;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public interface IChangeSpellData
    {
        ChangeSlotSpellDataType ChangeSlotSpellDataType { get; }
        void ReadBodyInternal(PacketReader reader);
        void WriteBodyInternal(PacketWriter writer);
    }

    public static class ChangeSpellDataExtension
    {
        public static IChangeSpellData ReadChangeSpellData(this PacketReader reader)
        {
            IChangeSpellData data;
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
            data.ReadBodyInternal(reader);
            return data;
        }
        public static void WriteChangeSpellData(this PacketWriter writer, IChangeSpellData data)
        {
            writer.WriteUInt32((uint)data.ChangeSlotSpellDataType);
            data.WriteBodyInternal(writer);
        }
    }

    public class ChangeSpellDataUnknown : IChangeSpellData
    {
        private ChangeSlotSpellDataType _changeSlotSpellDataType;
        public ChangeSpellDataUnknown() { }
        public ChangeSpellDataUnknown(ChangeSlotSpellDataType type) => _changeSlotSpellDataType = type;
        public ChangeSlotSpellDataType ChangeSlotSpellDataTypeRaw
        {
            get => _changeSlotSpellDataType;
            set => _changeSlotSpellDataType = value;
        }
        public ChangeSlotSpellDataType ChangeSlotSpellDataType => _changeSlotSpellDataType;
        public void ReadBodyInternal(PacketReader reader) { }
        public void WriteBodyInternal(PacketWriter writer) { }
    }

    public class ChangeSpellDataTargetingType : IChangeSpellData
    {
        public ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.TargetingType;
        public TargetingType TargetingType { get; set; }
        public void ReadBodyInternal(PacketReader reader)
        {
            TargetingType = reader.ReadTargetingType();
        }
        public void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteTargetingType(TargetingType);
        }
    }

    public class ChangeSpellDataSpellName : IChangeSpellData
    {
        public ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.SpellName;
        public string SpellName { get; set; } = "";
        public void ReadBodyInternal(PacketReader reader)
        {
            SpellName = reader.ReadZeroTerminatedString();
        }
        public void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteZeroTerminatedString(SpellName);
        }
    }

    public class ChangeSpellDataRange : IChangeSpellData
    {
        public ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.Range;
        public float CastRange { get; set; }
        public void ReadBodyInternal(PacketReader reader)
        {
            CastRange = reader.ReadFloat();
        }
        public void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(CastRange);
        }
    }

    public class ChangeSpellDataMaxGrowthRange : IChangeSpellData
    {
        public ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.MaxGrowthRange;
        public float OverrideMaxCastRange { get; set; }
        public void ReadBodyInternal(PacketReader reader)
        {
            OverrideMaxCastRange = reader.ReadFloat();
        }
        public void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(OverrideMaxCastRange);
        }
    }

    public class ChangeSpellDataRangeDisplay : IChangeSpellData
    {
        public ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.RangeDisplay;
        public float OverrideCastRangeDisplay { get; set; }
        public void ReadBodyInternal(PacketReader reader)
        {
            OverrideCastRangeDisplay = reader.ReadFloat();
        }
        public void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(OverrideCastRangeDisplay);
        }
    }

    public class ChangeSpellDataIconIndex : IChangeSpellData
    {
        public ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.IconIndex;
        public byte IconIndex { get; set; }
        public void ReadBodyInternal(PacketReader reader)
        {
            IconIndex = reader.ReadByte();
        }
        public void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteByte(IconIndex);
        }
    }

    public class ChangeSpellDataOffsetTarget : IChangeSpellData
    {
        public ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.OffsetTarget;
        public List<NetID> Targets { get; set; } = new List<NetID>();
        public void ReadBodyInternal(PacketReader reader)
        {
            int count = reader.ReadByte();
            for (int i = 0; i < count; i++)
            {
                Targets.Add(reader.ReadNetID());
            }
        }
        public void WriteBodyInternal(PacketWriter writer)
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
