using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class OnLeaveLocalVisiblityClient : GamePacket // 0x35
    {
        public override GamePacketID ID => GamePacketID.OnLeaveLocalVisiblityClient;
        public OnLeaveLocalVisiblityClient(){}

        public OnLeaveLocalVisiblityClient(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
