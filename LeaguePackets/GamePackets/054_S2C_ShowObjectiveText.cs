using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ShowObjectiveText : GamePacket // 0x36
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowObjectiveText;
        public string Message { get; set; } = "";
        public S2C_ShowObjectiveText(){}

        public S2C_ShowObjectiveText(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Message = reader.ReadFixedString(128);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(Message,128);
        }
    }
}
