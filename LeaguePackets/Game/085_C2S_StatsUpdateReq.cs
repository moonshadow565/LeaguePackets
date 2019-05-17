
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_StatsUpdateReq : GamePacket // 0x56
    {
        public override GamePacketID ID => GamePacketID.C2S_StatsUpdateReq;

        protected override void ReadBody(ByteReader reader)
        {

            reader.ReadPad(20);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WritePad(20);
        }
    }
}
