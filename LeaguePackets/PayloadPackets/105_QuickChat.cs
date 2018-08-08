using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public class QuickChat : PayloadPacket // 0x69
    {
        public override PayloadPacketID ID => PayloadPacketID.QuickChat;
        public ClientID ClientID { get; set; }
        public short MessageId { get; set; }

        public QuickChat(){}

        public QuickChat(PacketReader reader, ChannelID channelID)
        {
            ChannelID = channelID;
            ClientID = reader.ReadClientID();
            MessageId = reader.ReadInt16();
            ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            writer.WriteInt16(MessageId);
        }
    }
}
