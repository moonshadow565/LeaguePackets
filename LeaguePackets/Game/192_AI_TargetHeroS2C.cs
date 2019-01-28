
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class AI_TargetHeroS2C : GamePacket // 0xC0
    {
        public override GamePacketID ID => GamePacketID.AI_TargetHeroS2C;
        public uint TargetNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TargetNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TargetNetID);
        }
    }
}
