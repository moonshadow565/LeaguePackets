using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsBase
    {
        public virtual void ReadArgs(PacketReader reader) 
        { 
            reader.ReadPad(8);
        }
        public virtual void WriteArgs(PacketWriter writer) 
        { 
            writer.WritePad(8);
        }
    }
}
