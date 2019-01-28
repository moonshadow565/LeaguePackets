
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class Unused128 : GamePacket, IUnusedPacket // 0x80
    {
        public override GamePacketID ID => GamePacketID.Unused128;

        protected override void ReadBody(ByteReader reader)
        {
        }
        protected override void WriteBody(ByteWriter writer)
        {
        }
    }
}
