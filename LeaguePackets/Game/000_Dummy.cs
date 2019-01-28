
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class Dummy : GamePacket, IUnusedPacket // 0x0
    {
        public override GamePacketID ID => GamePacketID.Dummy;

        protected override void ReadBody(ByteReader reader)
        {
        }

        protected override void WriteBody(ByteWriter writer)
        {
        }
    }
}
