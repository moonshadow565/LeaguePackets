using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UNK_0x12E : GamePacket, IUnusedPacket // 0x12E
    {
        public override GamePacketID ID => GamePacketID.UNK_0x12E;
        //FIXME: 4.18+
        public static UNK_0x12E CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new UNK_0x12E();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
