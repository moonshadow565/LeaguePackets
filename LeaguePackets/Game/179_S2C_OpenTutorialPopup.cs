
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_OpenTutorialPopup : GamePacket // 0xB3
    {
        public override GamePacketID ID => GamePacketID.S2C_OpenTutorialPopup;
        public string MessageboxID { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.MessageboxID = reader.ReadFixedStringLast(128);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(MessageboxID, 128);
        }
    }
}
