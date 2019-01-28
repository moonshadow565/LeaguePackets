
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SetFadeOut_Push : GamePacket // 0xB2
    {
        public override GamePacketID ID => GamePacketID.SetFadeOut_Push;
        public short FadeId { get; set; }
        public float FadeTime { get; set; }
        public float FadeTargetValue { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.FadeId = reader.ReadInt16();
            this.FadeTime = reader.ReadFloat();
            this.FadeTargetValue = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt16(FadeId);
            writer.WriteFloat(FadeTime);
            writer.WriteFloat(FadeTargetValue);
        }
    }
}
