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
        public SPM_RemoveBBProfileListener(){}

        public SPM_RemoveBBProfileListener(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
