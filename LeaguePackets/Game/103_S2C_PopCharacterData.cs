
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PopCharacterData : GamePacket // 0x67
    {
        public override GamePacketID ID => GamePacketID.S2C_PopCharacterData;
        public uint PopID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.PopID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(PopID);
        }
    }
}
