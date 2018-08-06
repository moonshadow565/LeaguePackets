using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_HierarchicalProfilerUpdate : GamePacket, IUnusedPacket  // 0x1
    {
        public override GamePacketID ID => GamePacketID.SPM_HierarchicalProfilerUpdate;
        public static SPM_HierarchicalProfilerUpdate CreateBody(PacketReader reader, NetID senderNetID) 
        {
            var result = new SPM_HierarchicalProfilerUpdate();
            result.SenderNetID = senderNetID;
            return result;
        }
    }
}
