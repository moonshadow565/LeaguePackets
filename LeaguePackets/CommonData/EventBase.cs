using System;
using LeaguePackets.Common;
using LeaguePackets.CommonData.Events;

namespace LeaguePackets.CommonData
{
    public abstract class EventBase<TArgs> : Event where TArgs : ArgsBase, new()
    {
        public TArgs Args { get; set; } = new TArgs();
        public NetID Source { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            Source = reader.ReadNetID();
            Args.ReadArgs(reader);
        }

        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteNetID(Source);
            Args.WriteArgs(writer);
        }
    }
}
