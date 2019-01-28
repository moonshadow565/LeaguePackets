
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PlayEmote : GamePacket // 0x42
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayEmote;
        public byte EmoteID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.EmoteID = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(EmoteID);
        }
    }
}
