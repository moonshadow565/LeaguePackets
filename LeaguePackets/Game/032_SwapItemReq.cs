
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SwapItemReq : GamePacket // 0x20
    {
        public override GamePacketID ID => GamePacketID.SwapItemReq;
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
