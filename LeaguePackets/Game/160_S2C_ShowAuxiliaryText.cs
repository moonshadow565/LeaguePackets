
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ShowAuxiliaryText : GamePacket // 0xA0
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowAuxiliaryText;
        public string MessageID { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.MessageID = reader.ReadFixedStringLast(128);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(MessageID, 128);
        }
    }
}
