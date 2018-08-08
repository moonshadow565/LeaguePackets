using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_HierarchicalMemoryUpdate : GamePacket, IUnusedPacket // 0x4E
    {
        public override GamePacketID ID => GamePacketID.SPM_HierarchicalMemoryUpdate;
        public SPM_HierarchicalMemoryUpdate(){}

        public SPM_HierarchicalMemoryUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;


            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
