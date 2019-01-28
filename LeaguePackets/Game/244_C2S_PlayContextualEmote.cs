
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_PlayContextualEmote : GamePacket // 0xF4
    {
        public override GamePacketID ID => GamePacketID.C2S_PlayContextualEmote;

        protected override void ReadBody(ByteReader reader)
        {
            var result = new C2S_PlayContextualEmote(); 
        }
        protected override void WriteBody(ByteWriter writer) { }
    }
}
