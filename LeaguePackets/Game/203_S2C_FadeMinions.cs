
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_FadeMinions : GamePacket // 0xCB
    {
        public override GamePacketID ID => GamePacketID.S2C_FadeMinions;
        public byte TeamID { get; set; }
        public float FadeAmount { get; set; }
        public float FadeTime { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TeamID = reader.ReadByte();
            this.FadeAmount = reader.ReadFloat();
            this.FadeTime = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(TeamID);
            writer.WriteFloat(FadeAmount);
            writer.WriteFloat(FadeTime);
        }
    }
}
