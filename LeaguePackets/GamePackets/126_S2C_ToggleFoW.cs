using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ToggleFoW : GamePacket // 0x7E
    {
        public override GamePacketID ID => GamePacketID.S2C_ToggleFoW;
        public static S2C_ToggleFoW CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ToggleFoW();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;


            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
