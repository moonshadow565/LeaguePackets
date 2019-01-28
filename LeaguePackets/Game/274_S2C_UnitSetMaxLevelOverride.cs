
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetMaxLevelOverride : GamePacket // 0x112
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetMaxLevelOverride;
        public byte MaxLevelOverride { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.MaxLevelOverride = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(MaxLevelOverride);
        }
    }
}
