
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ModifyDebugCircleRadius : GamePacket, IUnusedPacket // 0x2D
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugCircleRadius;
        public int ObjectID { get; set; }
        public float Radius { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ObjectID = reader.ReadInt32();
            this.Radius = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteFloat(Radius);
        }
    }
}
