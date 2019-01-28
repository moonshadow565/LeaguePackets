
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UpdateRestrictedChatCount : GamePacket // 0xF9
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateRestrictedChatCount;
        public int Count { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Count = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(Count);
        }
    }
}
