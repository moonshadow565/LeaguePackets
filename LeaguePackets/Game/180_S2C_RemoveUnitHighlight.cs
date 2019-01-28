
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_RemoveUnitHighlight : GamePacket // 0xB4
    {
        public override GamePacketID ID => GamePacketID.S2C_RemoveUnitHighlight;
        public uint NetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
        }
    }
}
