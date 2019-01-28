
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_SetCircularMovementRestriction : GamePacket // 0x6
    {
        public override GamePacketID ID => GamePacketID.S2C_SetCircularMovementRestriction;
        public Vector3 Center { get; set; }
        public float Radius { get; set; }
        public bool RestrictCamera { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Center = reader.ReadVector3();
            this.Radius = reader.ReadFloat();

            var bitfield = reader.ReadByte();
            this.RestrictCamera = (bitfield & 0x01u) != 0; 
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(Center);
            writer.WriteFloat(Radius);

            byte bitfield = 0;
            if (RestrictCamera) 
                bitfield |= 1;
            
            writer.WriteByte(bitfield);
        }
    }
}
