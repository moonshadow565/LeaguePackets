using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_HandleUIHighlight : GamePacket // 0xCA
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleUIHighlight;
        public UIHighlightCommand UIHighlightCommand { get; set; }
        public UIElement UIElement { get; set; }
        public static S2C_HandleUIHighlight CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_HandleUIHighlight();
            result.SenderNetID = senderNetID;
            result.UIHighlightCommand = reader.ReadUIHighlightCommand();
            result.UIElement = reader.ReadUIElement();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUIHighlightCommand(UIHighlightCommand);
            writer.WriteUIElement(UIElement);
        }
    }
}
