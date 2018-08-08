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
        public static QuickChat CreateBody(PacketReader reader, ChannelID channelID)
        {
            var result = new QuickChat();
            result.ChannelID = channelID;
            result.ClientID = reader.ReadClientID();
            result.MessageId = reader.ReadInt16();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            writer.WriteInt16(MessageId);
        }
    }
}
