
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class Unused221 : GamePacket, IUnusedPacket // 0xDD
    {
        public override GamePacketID ID => GamePacketID.Unused221;

        protected override void ReadBody(ByteReader reader)
        {
        }
        protected override void WriteBody(ByteWriter writer) { }
    }
}
