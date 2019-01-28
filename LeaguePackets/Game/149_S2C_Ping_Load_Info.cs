
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class S2C_Ping_Load_Info : GamePacket // 0x95
    {
        public override GamePacketID ID => GamePacketID.S2C_Ping_Load_Info;
        public ConnectionInfo ConnectionInfo { get; set; } = new ConnectionInfo();

        protected override void ReadBody(ByteReader reader)
        {

            this.ConnectionInfo = reader.ReadConnectionInfo();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteConnectionInfo(ConnectionInfo);
        }
    }
}
