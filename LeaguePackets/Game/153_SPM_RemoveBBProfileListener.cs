
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SPM_RemoveBBProfileListener : GamePacket, IUnusedPacket // 0x99
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveBBProfileListener;

        protected override void ReadBody(ByteReader reader) 
        {
        }
        protected override void WriteBody(ByteWriter writer) {}
    }
}
