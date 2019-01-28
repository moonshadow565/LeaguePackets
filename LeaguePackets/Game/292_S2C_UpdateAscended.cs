
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UpdateAscended : GamePacket // 0x124
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateAscended;
        public uint AscendedNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.AscendedNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(AscendedNetID);
        }
    }
}
