
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_DebugLogGoldSources : GamePacket // 0x11A
    {
        public override GamePacketID ID => GamePacketID.S2C_DebugLogGoldSources;
        public string Message { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.Message = reader.ReadFixedStringLast(512);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(this.Message, 512);
        }
    }
}
