
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_EndOfGameEvent : GamePacket // 0xC5
    {
        public override GamePacketID ID => GamePacketID.S2C_EndOfGameEvent;
        public bool TeamIsOrder { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TeamIsOrder = reader.ReadBool();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(TeamIsOrder);
        }
    }
}
