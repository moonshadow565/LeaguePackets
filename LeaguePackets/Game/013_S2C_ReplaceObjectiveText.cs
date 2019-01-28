
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ReplaceObjectiveText : GamePacket // 0xD
    {
        public override GamePacketID ID => GamePacketID.S2C_ReplaceObjectiveText;
        public string TextID { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.TextID = reader.ReadFixedStringLast(128);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(TextID, 128);
        }
    }
}
