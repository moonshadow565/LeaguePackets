using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsBase
    {
        public uint OtherNetID { get; set; }
        public virtual void ReadArgs(ByteReader reader) 
        {
            OtherNetID = reader.ReadUInt32();
        }
        public virtual void WriteArgs(ByteWriter writer) 
        {
            writer.WriteUInt32(OtherNetID);
        }
    }
}
