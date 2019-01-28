
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SPM_HierarchicalMemoryUpdate : GamePacket, IUnusedPacket // 0x4E
    {
        public override GamePacketID ID => GamePacketID.SPM_HierarchicalMemoryUpdate;

        protected override void ReadBody(ByteReader reader)
        {
        }
        protected override void WriteBody(ByteWriter writer) {}
    }
}
