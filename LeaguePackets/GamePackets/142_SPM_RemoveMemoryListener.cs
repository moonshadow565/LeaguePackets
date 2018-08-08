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
        public SPM_RemoveMemoryListener(){}

        public SPM_RemoveMemoryListener(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
