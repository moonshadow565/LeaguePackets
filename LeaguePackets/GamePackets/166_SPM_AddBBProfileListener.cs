using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_AddBBProfileListener : GamePacket, IUnusedPacket // 0xA6
    {
        public override GamePacketID ID => GamePacketID.SPM_AddBBProfileListener;
        public static SPM_AddBBProfileListener CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SPM_AddBBProfileListener();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;


            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
