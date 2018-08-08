using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Unused128 : GamePacket, IUnusedPacket // 0x80
    {
        public override GamePacketID ID => GamePacketID.Unused128;
        public static Unused128 CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new Unused128();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            throw new NotImplementedException("Unused128.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("Unused128.Write");
        }
    }
}
