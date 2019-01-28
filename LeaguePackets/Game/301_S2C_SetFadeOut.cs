
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetFadeOut : GamePacket, IUnusedPacket // 0x12D
    {
        public override GamePacketID ID => GamePacketID.S2C_SetFadeOut;
        public float FadeTime { get; set; }
        public float FadeTargetValue { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.FadeTime = reader.ReadFloat();
            this.FadeTargetValue = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(FadeTime);
            writer.WriteFloat(FadeTargetValue);
        }
    }
}
