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
        public static S2C_ToggleUIHighlight CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ToggleUIHighlight();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.ElementID = reader.ReadByte();
            result.ElementType = reader.ReadByte();
            result.ElementNumber = reader.ReadByte();
            result.ElementSubCategory = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            result.Enabled = (bitfield & 1) != 0;
        
            return result;
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
