using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_RemoveBBProfileListener : GamePacket, IUnusedPacket // 0x99
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveBBProfileListener;
        public static SPM_RemoveBBProfileListener CreateBody(PacketReader reader, NetID senderNetID) 
        {
            var result = new SPM_RemoveBBProfileListener();
            result.SenderNetID = senderNetID;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
