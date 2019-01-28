
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_HandleGameScore : GamePacket // 0xD4
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleGameScore;
        public uint TeamID { get; set; }
        public int Score { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TeamID = reader.ReadUInt32();
            this.Score = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TeamID);
            writer.WriteInt32(Score);
        }
    }
}
