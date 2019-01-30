using System;
namespace LeaguePackets.Game.Events
{
    public class ArgsGlobalMessageGeneric: ArgsBase
    {
        public int MapNumber { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            MapNumber = reader.ReadInt32();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteInt32(MapNumber);
        }
    }
}
