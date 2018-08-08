using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_QueryStatusReq : GamePacket // 0x14
    {
        public override GamePacketID ID => GamePacketID.C2S_QueryStatusReq;
        public C2S_QueryStatusReq(){}

        public C2S_QueryStatusReq(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;


            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
