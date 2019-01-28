
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_NotifyContextualSituation : GamePacket // 0x121
    {
        public override GamePacketID ID => GamePacketID.S2C_NotifyContextualSituation;
        public uint SituationNameHash { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SituationNameHash = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(SituationNameHash);
        }
    }
}
