
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_EndSpawn : GamePacket // 0x11
    {
        public override GamePacketID ID => GamePacketID.S2C_EndSpawn;

        protected override void ReadBody(ByteReader reader)
        {
        }
        protected override void WriteBody(ByteWriter writer) {}
    }
}
