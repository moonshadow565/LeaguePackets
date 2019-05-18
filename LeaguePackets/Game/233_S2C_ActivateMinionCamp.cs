
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_ActivateMinionCamp : GamePacket // 0xE9
    {
        public override GamePacketID ID => GamePacketID.S2C_ActivateMinionCamp;
        public Vector3 Position { get; set; }
        public string MinimapIcon { get; set; } = "";
        public byte CampIndex { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            this.Position = reader.ReadVector3();
            this.MinimapIcon = reader.ReadFixedString(64);
            this.CampIndex = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteFixedString(MinimapIcon, 64);
            writer.WriteByte(CampIndex);
        }
    }
}
