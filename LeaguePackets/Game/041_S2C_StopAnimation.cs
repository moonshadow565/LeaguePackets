
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_StopAnimation : GamePacket // 0x29
    {
        public override GamePacketID ID => GamePacketID.S2C_StopAnimation;
        public bool Fade { get; set; }
        public bool IgnoreLock { get; set; }
        // StopAll only applied when AnimationName is empty/null
        public bool StopAll { get; set; }
        public string AnimationName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            byte flags = reader.ReadByte();
            this.Fade = (flags & 1) != 0;
            this.IgnoreLock = (flags & 2) != 0;
            this.StopAll = (flags & 4) != 0;
            this.AnimationName = reader.ReadFixedStringLast(64);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte flags = 0;
            if (Fade)
                flags |= 1;
            if (IgnoreLock)
                flags |= 2;
            if (StopAll)
                flags |= 4;
            writer.WriteByte(flags);
            writer.WriteFixedStringLast(AnimationName, 64);
        }
    }
}
