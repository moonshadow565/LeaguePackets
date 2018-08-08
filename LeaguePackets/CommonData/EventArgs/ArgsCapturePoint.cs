using System;
namespace LeaguePackets.CommonData.EventArgs
{
    public abstract class ArgsCapturePoint : ArgsBase
    {
        public uint CapturePoint { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            CapturePoint = reader.ReadUInt32();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteUInt32(CapturePoint);
        }
    }
}
