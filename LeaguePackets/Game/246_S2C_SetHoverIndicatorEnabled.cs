
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetHoverIndicatorEnabled : GamePacket // 0xF6
    {
        public override GamePacketID ID => GamePacketID.S2C_SetHoverIndicatorEnabled;
        public bool Enabled { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            this.Enabled = reader.ReadBool();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(Enabled);
        }
    }
}
