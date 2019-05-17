
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ShowObjectiveText : GamePacket // 0x36
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowObjectiveText;
        public string Message { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.Message = reader.ReadFixedStringLast(128);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(Message,128);
        }
    }
}
