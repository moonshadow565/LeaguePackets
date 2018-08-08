using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SynchSimTimeC2S : GamePacket // 0x8
    {
        public override GamePacketID ID => GamePacketID.SynchSimTimeC2S;
        public float TimeLastServer { get; set; }
        public float TimeLastClient { get; set; }
        public static SynchSimTimeC2S CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SynchSimTimeC2S();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TimeLastServer = reader.ReadFloat();
            result.TimeLastClient = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(TimeLastServer);
            writer.WriteFloat(TimeLastClient);
        }
    }
}
