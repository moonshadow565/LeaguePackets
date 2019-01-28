
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_OnTutorialPopupClosed : GamePacket // 0xCC
    {
        public override GamePacketID ID => GamePacketID.C2S_OnTutorialPopupClosed;

        protected override void ReadBody(ByteReader reader) 
        {
        }
        protected override void WriteBody(ByteWriter writer){}
    }
}
