
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitChangeTeam : GamePacket // 0xD7
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitChangeTeam;
        public uint UnitNetID { get; set; }
        public uint TeamID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.UnitNetID = reader.ReadUInt32();
            this.TeamID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(UnitNetID);
            writer.WriteUInt32(TeamID);
        }
    }
}
