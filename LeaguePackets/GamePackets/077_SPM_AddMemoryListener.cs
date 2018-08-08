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
        public SPM_AddMemoryListener(){}

        public SPM_AddMemoryListener(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;


            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) { }
    }
}
