
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SpectatorMetaData : GamePacket // 0xEB
    {
        public override GamePacketID ID => GamePacketID.S2C_SpectatorMetaData;
        public string JsonMetaData { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.JsonMetaData = reader.ReadSizedString();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteSizedString(JsonMetaData);
        }
    }
}
