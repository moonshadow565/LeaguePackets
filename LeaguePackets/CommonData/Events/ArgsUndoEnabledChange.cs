using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsUndoEnabledChange : ArgsBase
    {
        public int UndoStackLength { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            UndoStackLength = reader.ReadInt32();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteInt32(UndoStackLength);
        }
    }
}
