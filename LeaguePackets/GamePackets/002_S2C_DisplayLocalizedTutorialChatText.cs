using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_DisplayLocalizedTutorialChatText : GamePacket // 0x2
    {
        public override GamePacketID ID => GamePacketID.S2C_DisplayLocalizedTutorialChatText;
        public string Message { get; set; } = "";
        public S2C_DisplayLocalizedTutorialChatText(){}

        public S2C_DisplayLocalizedTutorialChatText(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Message = reader.ReadFixedStringLast(128);
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedStringLast(Message, 128);
        }
    }
}
