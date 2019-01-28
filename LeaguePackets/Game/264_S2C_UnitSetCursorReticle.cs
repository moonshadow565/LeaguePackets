
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetCursorReticle : GamePacket // 0x108
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetCursorReticle;
        public float Radius { get; set; }
        public float SecondaryRadius { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Radius = reader.ReadFloat();
            this.SecondaryRadius = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(Radius);
            writer.WriteFloat(SecondaryRadius);
        }
    }
}
