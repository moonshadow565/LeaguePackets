
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SPM_RemoveMemoryListener : GamePacket, IUnusedPacket // 0x8E
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveMemoryListener;

        protected override void ReadBody(ByteReader reader) 
        {
        }
        protected override void WriteBody(ByteWriter writer) {}
    }
}
