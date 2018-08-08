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
        public static S2C_SystemMessage CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_SystemMessage();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.SourceNetID = reader.ReadNetID();
            result.Message = reader.ReadFixedString(512);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(SourceNetID);
            writer.WriteFixedString(Message, 512);
        }
    }
}
