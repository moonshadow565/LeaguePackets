
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SwapItemAns : GamePacket // 0x3E
    {
        public override GamePacketID ID => GamePacketID.SwapItemAns;
        public byte Source { get; set; }
        public byte Destination { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Source = reader.ReadByte();
            this.Destination = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Source);
            writer.WriteByte(Destination);
        }
    }
}
