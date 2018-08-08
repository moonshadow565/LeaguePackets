using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SwapItemReq : GamePacket // 0x20
    {
        public override GamePacketID ID => GamePacketID.SwapItemReq;
        public byte Source { get; set; }
        public byte Destination { get; set; }
        public static SwapItemReq CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SwapItemReq();
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
