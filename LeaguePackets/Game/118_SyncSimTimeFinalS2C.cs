
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SyncSimTimeFinalS2C : GamePacket // 0x76
    {
        public override GamePacketID ID => GamePacketID.SyncSimTimeFinalS2C;
        public float TimeLastClient { get; set; }
        public float TimeRTTLastOverhead { get; set; }
        public float TimeConvergance { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TimeLastClient = reader.ReadFloat();
            this.TimeRTTLastOverhead = reader.ReadFloat();
            this.TimeConvergance = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(TimeLastClient);
            writer.WriteFloat(TimeRTTLastOverhead);
            writer.WriteFloat(TimeConvergance);
        }
    }
}
