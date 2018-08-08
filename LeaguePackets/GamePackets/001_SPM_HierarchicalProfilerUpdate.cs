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
        public SPM_HierarchicalProfilerUpdate(){}

        public SPM_HierarchicalProfilerUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ExtraBytes = reader.ReadLeft();
        }
    }
}
