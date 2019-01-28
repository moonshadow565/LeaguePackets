
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetPARType : GamePacket // 0x113
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetPARType;
        public byte PARType { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            this.PARType = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(PARType);
        }
    }
}
