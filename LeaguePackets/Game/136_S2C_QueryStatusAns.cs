
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_QueryStatusAns : GamePacket // 0x88
    {
        public override GamePacketID ID => GamePacketID.S2C_QueryStatusAns;
        public bool Response { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Response = reader.ReadBool();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(Response);
        }
    }
}
