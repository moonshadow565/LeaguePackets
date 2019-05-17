
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class ServerTick : GamePacket // 0x28
    {
        public override GamePacketID ID => GamePacketID.ServerTick;
        public float Delta { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Delta = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(Delta);
        }
    }
}
