
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SynchVersionC2S : GamePacket // 0xBD
    {
        public override GamePacketID ID => GamePacketID.SynchVersionC2S;
        public int ClientID { get; set; }
        public string Version { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.ClientID = reader.ReadInt32();
            this.Version = reader.ReadFixedStringLast(256);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
            writer.WriteFixedStringLast(Version, 256);
        }
    }
}
