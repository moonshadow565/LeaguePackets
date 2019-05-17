
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_FadeOutMainSFX : GamePacket // 0x5F
    {
        public override GamePacketID ID => GamePacketID.S2C_FadeOutMainSFX;
        public float FadeTime { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.FadeTime = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(FadeTime);
        }
    }
}
