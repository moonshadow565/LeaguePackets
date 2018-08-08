using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Connected : GamePacket // 0x75
    {
        public override GamePacketID ID => GamePacketID.Connected;
        public ClientID ClientID { get; set; }
        public static Connected CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new Connected();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.ClientID = reader.ReadClientID();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
        }
    }
}
