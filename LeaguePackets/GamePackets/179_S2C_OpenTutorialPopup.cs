using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_OpenTutorialPopup : GamePacket // 0xB3
    {
        public override GamePacketID ID => GamePacketID.S2C_OpenTutorialPopup;
        public string MessageboxID { get; set; } = "";
        public S2C_OpenTutorialPopup(){}

        public S2C_OpenTutorialPopup(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.MessageboxID = reader.ReadFixedStringLast(128);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedStringLast(MessageboxID, 128);
        }
    }
}
