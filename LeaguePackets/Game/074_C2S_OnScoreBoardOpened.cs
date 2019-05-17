
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_OnScoreBoardOpened : GamePacket // 0x4B
    {
        public override GamePacketID ID => GamePacketID.C2S_OnScoreBoardOpened;

        protected override void ReadBody(ByteReader reader) 
        {
        }
        protected override void WriteBody(ByteWriter writer) {}
    }
}
