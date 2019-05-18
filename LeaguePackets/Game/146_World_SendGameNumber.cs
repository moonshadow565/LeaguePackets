
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class World_SendGameNumber : GamePacket // 0x92
    {
        public override GamePacketID ID => GamePacketID.World_SendGameNumber;
        public long GameID { get; set; }
        public string PlatformID { get; set; } = "";
        public string SummonerName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.GameID = reader.ReadInt64();
            this.PlatformID = reader.ReadFixedString(32);
            this.SummonerName = reader.ReadFixedStringLast(128);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt64(GameID);
            writer.WriteFixedString(PlatformID, 32);
            writer.WriteFixedStringLast(SummonerName, 128);
        }
    }
}
