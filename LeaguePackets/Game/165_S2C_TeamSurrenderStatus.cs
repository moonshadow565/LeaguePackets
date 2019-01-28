
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_TeamSurrenderStatus : GamePacket // 0xA5
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamSurrenderStatus;
        public uint SurrenderReason { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public uint TeamID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SurrenderReason = reader.ReadUInt32();
            this.ForVote = reader.ReadByte();
            this.AgainstVote = reader.ReadByte();
            this.TeamID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(SurrenderReason);
            writer.WriteByte(ForVote);
            writer.WriteByte(AgainstVote);
            writer.WriteUInt32(TeamID);
        }
    }
}
