
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_IncrementMinionKills : GamePacket // 0x11F
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementMinionKills;
        public uint PlayerNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.PlayerNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(PlayerNetID);
        }
    }
}
