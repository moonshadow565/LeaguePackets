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
        public S2C_HandleUIHighlight(){}

        public S2C_HandleUIHighlight(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.UIHighlightCommand = reader.ReadUIHighlightCommand();
            this.UIElement = reader.ReadUIElement();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUIHighlightCommand(UIHighlightCommand);
            writer.WriteUIElement(UIElement);
        }
    }
}
