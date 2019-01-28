
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_MoveRegion : GamePacket // 0x24
    {
        public override GamePacketID ID => GamePacketID.S2C_MoveRegion;
        public uint RegionNetID { get; set; }
        public Vector2 Position { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.RegionNetID = reader.ReadUInt32();
            this.Position = reader.ReadVector2();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(RegionNetID);
            writer.WriteVector2(Position);
        }
    }
}
