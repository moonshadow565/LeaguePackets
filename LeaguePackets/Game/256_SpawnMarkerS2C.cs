
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class SpawnMarkerS2C : GamePacket // 0x100
    {
        public override GamePacketID ID => GamePacketID.SpawnMarkerS2C;
        public uint NetID { get; set; }
        public byte NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public float VisibilitySize { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.VisibilitySize = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteByte(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteFloat(VisibilitySize);
        }
    }
}
