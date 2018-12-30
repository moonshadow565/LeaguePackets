using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsBase
    {
        public NetID OtherNetID { get; set; }
        public virtual void ReadArgs(PacketReader reader) 
        {
            OtherNetID = reader.ReadNetID();
        }
        public virtual void WriteArgs(PacketWriter writer) 
        {
            writer.WriteNetID(OtherNetID);
        }
    }
}
