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
        public S2C_DebugLogGoldSources(){}

        public S2C_DebugLogGoldSources(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Message = reader.ReadZeroTerminatedString();
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteZeroTerminatedString(Message);
        }
    }
}
