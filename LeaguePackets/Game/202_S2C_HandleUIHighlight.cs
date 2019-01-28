
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_HandleUIHighlight : GamePacket // 0xCA
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleUIHighlight;
        public byte UIHighlightCommand { get; set; }
        public byte UIElement { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.UIHighlightCommand = reader.ReadByte();
            this.UIElement = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(UIHighlightCommand);
            writer.WriteByte(UIElement);
        }
    }
}
