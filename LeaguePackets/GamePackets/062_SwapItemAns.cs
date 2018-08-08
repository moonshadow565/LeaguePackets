using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SwapItemAns : GamePacket // 0x3E
    {
        public override GamePacketID ID => GamePacketID.SwapItemAns;
        public byte Source { get; set; }
        public byte Destination { get; set; }
        public static SwapItemAns CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SwapItemAns();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Source = reader.ReadByte();
            result.Destination = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Source);
            writer.WriteByte(Destination);
        }
    }
}
