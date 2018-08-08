using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetFadeOut : GamePacket, IUnusedPacket // 0x12D
    {
        public override GamePacketID ID => GamePacketID.S2C_SetFadeOut;
        //FIXME: 4.18+
        public S2C_SetFadeOut(){}

        public S2C_SetFadeOut(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
