using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SystemMessage : GamePacket // 0xF7
    {
        public override GamePacketID ID => GamePacketID.S2C_SystemMessage;
        public NetID SourceNetID { get; set; }
        public string Message { get; set; } = "";
        public S2C_SystemMessage(){}

        public S2C_SystemMessage(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SourceNetID = reader.ReadNetID();
            this.Message = reader.ReadFixedStringLast(512);
            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(SourceNetID);
            writer.WriteFixedStringLast(Message, 512);
        }
    }
}
