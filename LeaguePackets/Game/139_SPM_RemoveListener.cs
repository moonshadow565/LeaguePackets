
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SPM_RemoveListener : GamePacket, IUnusedPacket // 0x8B
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveListener;

        protected override void ReadBody(ByteReader reader)
        {
        }
        protected override void WriteBody(ByteWriter writer) {}
    }
}
