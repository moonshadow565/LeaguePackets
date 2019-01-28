
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetLookAt : GamePacket // 0x10F
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetLookAt;
        public byte LookAtType { get; set; }
        public Vector3 TargetPosition { get; set; }
        public uint TargetNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.LookAtType = reader.ReadByte();
            this.TargetPosition = reader.ReadVector3();
            this.TargetNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(LookAtType);
            writer.WriteVector3(TargetPosition);
            writer.WriteUInt32(TargetNetID);
        }
    }
}
