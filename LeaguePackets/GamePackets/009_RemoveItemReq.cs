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
        public static RemoveItemReq CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new RemoveItemReq();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.Slot = (byte)(bitfield & 0x7Fu);
            result.Sell = (bitfield & 0x80) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(Slot & 0x7Fu);
            if (Sell)
                bitfield |= (byte)0x80u;
            writer.WriteByte(bitfield);
        }
    }
}
