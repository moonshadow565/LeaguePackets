using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_HierarchicalBBProfileUpdate : GamePacket, IUnusedPacket // 0xB6
    {
        public override GamePacketID ID => GamePacketID.SPM_HierarchicalBBProfileUpdate;
        public SPM_HierarchicalBBProfileUpdate(){}

        public SPM_HierarchicalBBProfileUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
