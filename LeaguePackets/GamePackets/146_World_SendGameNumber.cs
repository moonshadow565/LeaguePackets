using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class World_SendGameNumber : GamePacket // 0x92
    {
        public override GamePacketID ID => GamePacketID.World_SendGameNumber;
        public long GameID { get; set; }
        public string SummonerName { get; set; } = "";
        public static World_SendGameNumber CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new World_SendGameNumber();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.GameID = reader.ReadInt64();
            result.SummonerName = reader.ReadFixedString(128);
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt64(GameID);
            writer.WriteFixedString(SummonerName, 128);
        }
    }
}
