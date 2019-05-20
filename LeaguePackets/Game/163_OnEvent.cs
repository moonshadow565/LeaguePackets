
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;
using LeaguePackets.Game.Events;

namespace LeaguePackets.Game
{
    public class OnEvent : GamePacket // 0xA3
    {
        public override GamePacketID ID => GamePacketID.OnEvent;
        public IEvent Event { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            var id = reader.ReadByte();
            var ev = EventExtension.CreateEvent(id);
            ev.ReadArgs(reader);
            this.Event = ev;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte((byte)Event.ID);
            Event.WriteArgs(writer);
        }
    }
}
