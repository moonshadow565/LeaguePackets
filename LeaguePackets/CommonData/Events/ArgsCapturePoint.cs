using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsCapturePoint : ArgsBase
    {
        public uint CapturePoint { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            CapturePoint = reader.ReadUInt32();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteUInt32(CapturePoint);
        }
    }
}
