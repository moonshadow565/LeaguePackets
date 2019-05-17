
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_FaceDirection : GamePacket // 0x50
    {
        public override GamePacketID ID => GamePacketID.S2C_FaceDirection;
        public Vector3 Direction { get; set; }
        public bool DoLerpTime { get; set; }
        public float LerpTime { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte flags = reader.ReadByte();
            this.DoLerpTime = (flags & 1) != 0;

            this.Direction = reader.ReadVector3();
            this.LerpTime = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte flags = 0;
            if (DoLerpTime)
                flags |= 1;
            writer.WriteByte(flags);

            writer.WriteVector3(Direction);
            writer.WriteFloat(LerpTime);
        }
    }
}
