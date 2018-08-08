using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_DebugLogGoldSources : GamePacket // 0x11A
    {
        public override GamePacketID ID => GamePacketID.S2C_DebugLogGoldSources;
        public string Message { get; set; } = "";
        public static S2C_DebugLogGoldSources CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_DebugLogGoldSources();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Message = reader.ReadZeroTerminatedString();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteZeroTerminatedString(Message);
        }
    }
}
