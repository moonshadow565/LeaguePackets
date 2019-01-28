
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SynchSimTimeS2C : GamePacket // 0xC1
    {
        public override GamePacketID ID => GamePacketID.SynchSimTimeS2C;
        public float SynchTime { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SynchTime = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(SynchTime);
        }
    }
}
