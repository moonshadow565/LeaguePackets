using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UNK_0x12C : GamePacket, IUnusedPacket // 0x12C
    {
        public override GamePacketID ID => GamePacketID.UNK_0x12C;
        //FIXME: 4.18+
        public static UNK_0x12C CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new UNK_0x12C();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
