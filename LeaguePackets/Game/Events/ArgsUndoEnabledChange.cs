using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsUndoEnabledChange : ArgsBase
    {
        public int UndoStackLength { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            UndoStackLength = reader.ReadInt32();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteInt32(UndoStackLength);
        }
    }
}
