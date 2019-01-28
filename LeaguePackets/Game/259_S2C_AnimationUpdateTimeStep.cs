
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_AnimationUpdateTimeStep : GamePacket // 0x103
    {
        public override GamePacketID ID => GamePacketID.S2C_AnimationUpdateTimeStep;
        public float UpdateTimeStep { get; set; }
        public string AnimationName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.UpdateTimeStep = reader.ReadFloat();
            this.AnimationName = reader.ReadFixedStringLast(64);
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(UpdateTimeStep);
            writer.WriteFixedStringLast(AnimationName, 64);
        }
    }
}
