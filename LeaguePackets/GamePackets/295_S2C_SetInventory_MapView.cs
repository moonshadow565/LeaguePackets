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
        public static S2C_SetInventory_MapView CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_SetInventory_MapView();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
