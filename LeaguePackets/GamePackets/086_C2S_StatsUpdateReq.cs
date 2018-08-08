using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_StatsUpdateReq : GamePacket // 0x56
    {
        public override GamePacketID ID => GamePacketID.C2S_StatsUpdateReq;
        public C2S_StatsUpdateReq(){}

        public C2S_StatsUpdateReq(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            reader.ReadPad(20);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePad(20);
        }
    }
}
