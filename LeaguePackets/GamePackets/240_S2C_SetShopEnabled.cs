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
        public S2C_SetShopEnabled(){}

        public S2C_SetShopEnabled(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.Enabled = (bitfield & 1) != 0;
            this.ForceEnabled = (bitfield & 2) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
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
