
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SynchSimTimeC2S : GamePacket // 0x8
    {
        public override GamePacketID ID => GamePacketID.SynchSimTimeC2S;
        public float TimeLastServer { get; set; }
        public float TimeLastClient { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TimeLastServer = reader.ReadFloat();
            this.TimeLastClient = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(TimeLastServer);
            writer.WriteFloat(TimeLastClient);
        }
    }
}
