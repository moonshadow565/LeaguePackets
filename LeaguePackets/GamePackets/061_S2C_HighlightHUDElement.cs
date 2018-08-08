using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_HighlightHUDElement : GamePacket // 0x3D
    {
        public override GamePacketID ID => GamePacketID.S2C_HighlightHUDElement;
        public byte ElementPart { get; set; }
        public byte ElementType { get; set; }
        public byte ElementNumber{ get; set; }
        public byte ElementSubCategory { get; set; }
        public S2C_HighlightHUDElement(){}

        public S2C_HighlightHUDElement(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ElementPart = reader.ReadByte();
            this.ElementType = reader.ReadByte();
            this.ElementNumber = reader.ReadByte();
            this.ElementSubCategory = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(ElementPart);
            writer.WriteByte(ElementType);
            writer.WriteByte(ElementNumber);
            writer.WriteByte(ElementSubCategory);
        }
    }
}
