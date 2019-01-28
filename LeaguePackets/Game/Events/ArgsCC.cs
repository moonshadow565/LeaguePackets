using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsCC : ArgsBuff
    {
        public int BuffType { get; set; }
        public float FinalDuration { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            BuffType = reader.ReadInt32();
            FinalDuration = reader.ReadFloat();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteInt32(BuffType);
            writer.WriteFloat(FinalDuration);
        }
    }
}
