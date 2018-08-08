using System;
namespace LeaguePackets.CommonData
{
    public abstract class LocalVisibilityData
    {
        public abstract void ReadBodyInternal(PacketReader reader);
        public abstract void WriteBodyInternal(PacketWriter writer);
    }

    public static class LocalVisibilityDataExtension
    {
        public static LocalVisibilityData ReadLocalVisibilityData(this PacketReader reader)
        {
            var data = new LocalVisibilityDataUnknown();
            data.ReadBodyInternal(reader);
            return data;
        }

        public static void WriteLocalVisibilityData(this PacketWriter writer, LocalVisibilityData data)
        {
            data.WriteBodyInternal(writer);
        }
    }

    public class LocalVisibilityDataUnknown : LocalVisibilityData
    {
        public byte[] Data { get; set; } = new byte[0];
        public override void ReadBodyInternal(PacketReader reader) 
        {
            Data = reader.ReadLeft();
        }
        public override void WriteBodyInternal(PacketWriter writer) 
        {
            writer.WriteBytes(Data);
        }
    }

    public class LocalVisibilityDataAIBase : LocalVisibilityData
    {
        public float MaxHealth { get; set; }
        public float Health { get; set; }
        public override void ReadBodyInternal(PacketReader reader)
        {
            MaxHealth = reader.ReadFloat();
            Health = reader.ReadFloat();
        }
        public override void WriteBodyInternal(PacketWriter writer)
        {
            writer.WriteFloat(MaxHealth);
            writer.WriteFloat(Health);
        }
    }

    public class LocalVisibilityDataNeutralMinionHUD : LocalVisibilityData
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        public override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class LocalVisibilityDataSpellMissile : LocalVisibilityData
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        public override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class LocalVisibilityDataBuilding : LocalVisibilityData
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        public override void WriteBodyInternal(PacketWriter writer) { }
    }
}
