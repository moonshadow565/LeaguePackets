using System;
namespace LeaguePackets.CommonData.EventArgs
{
    public abstract class ArgsCC : ArgsBuff
    {
        public int BuffType { get; set; }
        public float FinalDuration { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            BuffType = reader.ReadInt32();
            FinalDuration = reader.ReadFloat();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteInt32(BuffType);
            writer.WriteFloat(FinalDuration);
        }
    }
}
