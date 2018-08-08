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
        public SwapItemAns(){}

        public SwapItemAns(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Source = reader.ReadByte();
            this.Destination = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Source);
            writer.WriteByte(Destination);
        }
    }
}
