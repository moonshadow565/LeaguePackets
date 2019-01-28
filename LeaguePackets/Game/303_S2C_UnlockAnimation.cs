
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnlockAnimation : GamePacket // 0x12F
    {
        public override GamePacketID ID => GamePacketID.S2C_UnlockAnimation;
        public string AnimationName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.AnimationName = reader.ReadFixedStringLast(64);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(AnimationName, 64);
        }
    }
}
