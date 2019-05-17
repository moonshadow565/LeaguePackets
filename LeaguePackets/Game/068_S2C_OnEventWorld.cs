
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
    public class S2C_OnEventWorld : GamePacket // 0x45
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEventWorld;
        public EventWorld EventWorld = new EventWorld();

        protected override void ReadBody(ByteReader reader)
        {
            this.EventWorld = reader.ReadEventWorld();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteEventWorld(EventWorld);
        }
    }
}
