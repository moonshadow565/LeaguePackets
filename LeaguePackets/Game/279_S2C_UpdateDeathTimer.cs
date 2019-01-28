
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UpdateDeathTimer : GamePacket // 0x117
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateDeathTimer;
        public float DeathDuration { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.DeathDuration = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(DeathDuration);
        }
    }
}
