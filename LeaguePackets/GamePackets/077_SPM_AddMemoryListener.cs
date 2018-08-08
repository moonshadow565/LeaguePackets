using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_AddMemoryListener : GamePacket, IUnusedPacket // 0x4D
    {
        public override GamePacketID ID => GamePacketID.SPM_AddMemoryListener;
        public static SPM_AddMemoryListener CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SPM_AddMemoryListener();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;


            return result;
        }
        public override void WriteBody(PacketWriter writer) { }
    }
}
