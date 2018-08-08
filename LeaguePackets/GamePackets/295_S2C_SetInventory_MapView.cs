using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetInventory_MapView : GamePacket, IUnusedPacket // 0x127
    {
        public override GamePacketID ID => GamePacketID.S2C_SetInventory_MapView;
        //FIXME: 4.18+t
        public S2C_SetInventory_MapView(){}

        public S2C_SetInventory_MapView(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
