using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class AI_Command : GamePacket // 0x7A
    {
        public override GamePacketID ID => GamePacketID.AI_Command;
        public string Command { get; set; } = "";
        public static AI_Command CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new AI_Command();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Command = reader.ReadFixedString(128);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(Command, 128);
        }
    }
}
