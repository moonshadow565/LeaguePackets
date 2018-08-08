using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_OnTutorialPopupClosed : GamePacket // 0xCC
    {
        public override GamePacketID ID => GamePacketID.C2S_OnTutorialPopupClosed;
        public C2S_OnTutorialPopupClosed(){}

        public C2S_OnTutorialPopupClosed(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer){}
    }
}
