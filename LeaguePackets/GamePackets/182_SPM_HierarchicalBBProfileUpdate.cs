using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_HierarchicalBBProfileUpdate : GamePacket // 0xB6
    {
        public override GamePacketID ID => GamePacketID.SPM_HierarchicalBBProfileUpdate;
        public static SPM_HierarchicalBBProfileUpdate CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new SPM_HierarchicalBBProfileUpdate();
            result.SenderNetID = senderNetID;
            throw new NotImplementedException("SPM_HierarchicalBBProfileUpdate.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("SPM_HierarchicalBBProfileUpdate.Write");
        }
    }
}
