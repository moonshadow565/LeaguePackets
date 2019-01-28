
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class Cheat : GamePacket, IUnusedPacket // 0xAD
    {
        public override GamePacketID ID => GamePacketID.Cheat;

        protected override void ReadBody(ByteReader reader)
        {
        }
        protected override void WriteBody(ByteWriter writer)
        {
        }
    }
}
