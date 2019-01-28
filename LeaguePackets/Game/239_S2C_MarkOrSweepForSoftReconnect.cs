
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_MarkOrSweepForSoftReconnect : GamePacket // 0xEF
    {
        public override GamePacketID ID => GamePacketID.S2C_MarkOrSweepForSoftReconnect;
        public bool Unknown1 { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Unknown1 = reader.ReadUInt32() == 1;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(Unknown1 ? 1u : 0u);
        }
    }
}
