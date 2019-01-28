
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_ForceDead : GamePacket // 0x1B
    {
        public override GamePacketID ID => GamePacketID.NPC_ForceDead;
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
