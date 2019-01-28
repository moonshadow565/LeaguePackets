
using LeaguePackets.Game.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ModifyDebugObjectColor : GamePacket, IUnusedPacket // 0x90
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugObjectColor;
        public int ObjectID { get; set; }
        public Color Color { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ObjectID = reader.ReadInt32();
            this.Color = reader.ReadColor();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteColor(Color);
        }
    }
}
