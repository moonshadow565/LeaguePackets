using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ToggleUIHighlight : GamePacket // 0x4F
    {
        public override GamePacketID ID => GamePacketID.S2C_ToggleUIHighlight;
        public byte ElementID { get; set; }
        public byte ElementType { get; set; }
        public byte ElementNumber { get; set; }
        public byte ElementSubCategory { get; set; }
        public bool Enabled { get; set; }
        public S2C_ToggleUIHighlight(){}

        public S2C_ToggleUIHighlight(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ElementID = reader.ReadByte();
            this.ElementType = reader.ReadByte();
            this.ElementNumber = reader.ReadByte();
            this.ElementSubCategory = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.Enabled = (bitfield & 1) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(ElementID);
            writer.WriteByte(ElementType);
            writer.WriteByte(ElementNumber);
            writer.WriteByte(ElementSubCategory);
            byte bitfield = 0;
            if (Enabled)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
