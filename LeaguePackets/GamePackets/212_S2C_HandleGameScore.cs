using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_HandleGameScore : GamePacket // 0xD4
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleGameScore;
        public TeamID TeamID { get; set; }
        public int Score { get; set; }
        public static S2C_HandleGameScore CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_HandleGameScore();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TeamID = reader.ReadTeamID();
            result.Score = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteTeamID(TeamID);
            writer.WriteInt32(Score);
        }
    }
}
