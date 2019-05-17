
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_CameraBehavior : GamePacket // 0x73
    {
        public override GamePacketID ID => GamePacketID.S2C_CameraBehavior;
        public Vector3 Position { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Position = reader.ReadVector3();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(Position);
        }
    }
}
