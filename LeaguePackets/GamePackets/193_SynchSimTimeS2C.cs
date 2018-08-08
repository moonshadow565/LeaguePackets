using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SynchSimTimeS2C : GamePacket // 0xC1
    {
        public override GamePacketID ID => GamePacketID.SynchSimTimeS2C;
        public float SynchTime { get; set; }
        public static SynchSimTimeS2C CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SynchSimTimeS2C();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.SynchTime = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(SynchTime);
        }
    }
}
