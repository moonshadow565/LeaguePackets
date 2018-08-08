using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetCanSurrender : GamePacket // 0x10E
    {
        public override GamePacketID ID => GamePacketID.S2C_SetCanSurrender;
        public bool CanSurrender { get; set; }
        public static S2C_SetCanSurrender CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_SetCanSurrender();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.CanSurrender = (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (CanSurrender)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
