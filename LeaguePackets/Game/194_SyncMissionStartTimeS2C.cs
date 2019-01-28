
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SyncMissionStartTimeS2C : GamePacket // 0xC2
    {
        public override GamePacketID ID => GamePacketID.SyncMissionStartTimeS2C;
        public float StartTime { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.StartTime = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(StartTime);
        }
    }
}
