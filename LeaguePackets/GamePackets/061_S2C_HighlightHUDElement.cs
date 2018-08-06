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
        public static S2C_HighlightHUDElement CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_HighlightHUDElement();
            result.SenderNetID = senderNetID;
            result.ElementPart = reader.ReadByte();
            result.ElementType = reader.ReadByte();
            result.ElementNumber = reader.ReadByte();
            result.ElementSubCategory = reader.ReadByte();
        
            return result;
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
