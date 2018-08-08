using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Unused222 : GamePacket, IUnusedPacket // 0xDE
    {
        public override GamePacketID ID => GamePacketID.Unused222;
        public static Unused222 CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            var result = new Unused222();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
