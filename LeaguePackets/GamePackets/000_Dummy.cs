using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Dummy : GamePacket // 0x0
    {
        public override GamePacketID ID => GamePacketID.Dummy;
        public static Dummy CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new Dummy();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
