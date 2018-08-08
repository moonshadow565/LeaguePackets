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
        public SwapItemReq(){}

        public SwapItemReq(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
