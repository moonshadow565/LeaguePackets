
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_HighlightHUDElement : GamePacket // 0x3D
    {
        public override GamePacketID ID => GamePacketID.S2C_HighlightHUDElement;
        public byte ElementPart { get; set; }
        public byte ElementType { get; set; }
        public byte ElementNumber{ get; set; }
        public byte ElementSubCategory { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ElementPart = reader.ReadByte();
            this.ElementType = reader.ReadByte();
            this.ElementNumber = reader.ReadByte();
            this.ElementSubCategory = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(ElementPart);
            writer.WriteByte(ElementType);
            writer.WriteByte(ElementNumber);
            writer.WriteByte(ElementSubCategory);
        }
    }
}
