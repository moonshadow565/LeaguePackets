using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsCapturePoint : ArgsBase
    {
        public uint CapturePoint { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            CapturePoint = reader.ReadUInt32();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteUInt32(CapturePoint);
        }
    }
}
