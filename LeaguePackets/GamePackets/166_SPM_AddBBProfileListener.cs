using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_AddBBProfileListener : GamePacket, IUnusedPacket // 0xA6
    {
        public override GamePacketID ID => GamePacketID.SPM_AddBBProfileListener;
        public SPM_AddBBProfileListener(){}

        public SPM_AddBBProfileListener(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;


            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
