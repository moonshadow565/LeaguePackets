using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class RemoveItemReq : GamePacket // 0x9
    {
        public override GamePacketID ID => GamePacketID.RemoveItemReq;
        public byte Slot { get; set; }
        public bool Sell { get; set; }
        public RemoveItemReq(){}

        public RemoveItemReq(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Slot = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.Sell = (bitfield & 0x01) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            byte bitfield = 0;
            if (Sell)
                bitfield |= (byte)0x01;
            writer.WriteByte(bitfield);
        }
    }
}
