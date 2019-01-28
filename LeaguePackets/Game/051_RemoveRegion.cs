
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class RemoveRegion : GamePacket // 0x33
    {
        public override GamePacketID ID => GamePacketID.RemoveRegion;
        public uint RegionNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.RegionNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(RegionNetID);
        }
    }
}
