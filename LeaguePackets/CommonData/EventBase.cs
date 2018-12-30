using System;
using LeaguePackets.Common;
using LeaguePackets.CommonData.Events;

namespace LeaguePackets.CommonData
{
    public abstract class EventBase<TArgs> : Event where TArgs : ArgsBase, new()
    {
        public TArgs Args { get; set; } = new TArgs();
        public override void ReadArgs(PacketReader reader)
        {
            Args.ReadArgs(reader);
        }

        public override void WriteArgs(PacketWriter writer)
        {
            Args.WriteArgs(writer);
        }
    }
}
