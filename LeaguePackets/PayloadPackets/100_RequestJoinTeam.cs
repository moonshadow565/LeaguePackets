using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.PayloadPackets
{
    public class RequestJoinTeam : PayloadPacket // 0x64
    {
        public override PayloadPacketID ID => PayloadPacketID.RequestJoinTeam;
        public ClientID PlayerID { get; set; }
        public NetTeam Team { get; set; }

        public RequestJoinTeam() {}

        public RequestJoinTeam(PacketReader reader, ChannelID channelID)
        {
            ChannelID = channelID;
            PlayerID = reader.ReadClientID();
            Team = reader.ReadNetTeam();
            ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(PlayerID);
            writer.WriteNetTeam(Team);
        }
    }
}
