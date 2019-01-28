
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.LoadScreen
{
    public class RequestJoinTeam : LoadScreenPacket // 0x64
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.RequestJoinTeam;
        public int ClientID { get; set; }
        public uint NetTeamID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            ClientID = reader.ReadInt32();
            NetTeamID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
            writer.WriteUInt32(NetTeamID);
        }
    }
}
