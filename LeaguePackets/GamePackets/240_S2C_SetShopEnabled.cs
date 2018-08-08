using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetShopEnabled : GamePacket // 0xF0
    {
        public override GamePacketID ID => GamePacketID.S2C_SetShopEnabled;
        public bool Enabled { get; set; }
        public bool ForceEnabled { get; set; }
        public static S2C_SetShopEnabled CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_SetShopEnabled();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.Enabled = (bitfield & 1) != 0;
            result.ForceEnabled = (bitfield & 2) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Enabled)
                bitfield |= 1;
            if (ForceEnabled)
                bitfield |= 2;
            writer.WriteByte(bitfield);
        }
    }
}
