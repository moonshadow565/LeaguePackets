using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_RemoveMemoryListener : GamePacket, IUnusedPacket // 0x8E
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveMemoryListener;
        public static SPM_RemoveMemoryListener CreateBody(PacketReader reader, NetID senderNetID) 
        {
            var result = new SPM_RemoveMemoryListener();
            result.SenderNetID = senderNetID;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
