using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_SamplingProfilerUpdate : GamePacket, IUnusedPacket // 0xC7
    {
        public override GamePacketID ID => GamePacketID.SPM_SamplingProfilerUpdate;
        public SPM_SamplingProfilerUpdate(){}

        public SPM_SamplingProfilerUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
