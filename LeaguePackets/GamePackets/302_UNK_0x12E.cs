using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UNK_0x12E : GamePacket, IUnusedPacket // 0x12E
    {
        public override GamePacketID ID => GamePacketID.UNK_0x12E;
        //FIXME: 4.18+
        public UNK_0x12E(){}

        public UNK_0x12E(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
