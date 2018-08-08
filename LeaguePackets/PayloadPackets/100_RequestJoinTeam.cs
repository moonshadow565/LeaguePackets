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
        public static RequestJoinTeam CreateBody(PacketReader reader, ChannelID channelID)
        {
            var result = new RequestJoinTeam();
            result.ChannelID = channelID;
            result.PlayerID = reader.ReadClientID();
            result.Team = reader.ReadNetTeam();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(PlayerID);
            writer.WriteNetTeam(Team);
        }
    }
}
