
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class Connected : GamePacket // 0x75
    {
        public override GamePacketID ID => GamePacketID.Connected;
        public int ClientID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ClientID = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
        }
    }
}
