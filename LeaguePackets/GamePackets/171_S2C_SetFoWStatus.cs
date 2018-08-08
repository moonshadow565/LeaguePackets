using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetFoWStatus : GamePacket // 0xAB
    {
        public override GamePacketID ID => GamePacketID.S2C_SetFoWStatus;
        public bool Enabled { get; set; }
        public static S2C_SetFoWStatus CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_SetFoWStatus();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.Enabled = (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Enabled)
                bitfield |= 1; 
            writer.WriteByte(bitfield);
        }
    }
}
