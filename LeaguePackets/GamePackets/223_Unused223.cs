using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Unused223 : GamePacket, IUnusedPacket // 0xDF
    {
        public override GamePacketID ID => GamePacketID.Unused223;
        public static Unused223 CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            var result = new Unused223();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            return result;
        }
        public override void WriteBody(PacketWriter writer) { }
    }
}
