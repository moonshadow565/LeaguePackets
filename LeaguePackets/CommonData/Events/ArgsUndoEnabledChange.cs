using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsUndoEnabledChange : ArgsBase
    {
        public int UndoStackLength { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            reader.ReadPad(4);
            UndoStackLength = reader.ReadInt32();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WritePad(4);
            writer.WriteInt32(UndoStackLength);
        }
    }
}
