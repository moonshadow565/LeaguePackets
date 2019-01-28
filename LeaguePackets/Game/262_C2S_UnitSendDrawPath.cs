
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class C2S_UnitSendDrawPath : GamePacket // 0x106
    {
        public override GamePacketID ID => GamePacketID.C2S_UnitSendDrawPath;
        public uint TargetNetID { get; set; }
        public byte DrawPathNodeType { get; set; }
        public Vector3 Point { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TargetNetID = reader.ReadUInt32();
            this.DrawPathNodeType = reader.ReadByte();
            this.Point = reader.ReadVector3();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TargetNetID);
            writer.WriteByte(DrawPathNodeType);
            writer.WriteVector3(Point);
        }
    }
}
