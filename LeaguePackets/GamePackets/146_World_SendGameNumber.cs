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
        public World_SendGameNumber(){}

        public World_SendGameNumber(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.GameID = reader.ReadInt64();
            this.SummonerName = reader.ReadFixedString(128);
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt64(GameID);
            writer.WriteFixedString(SummonerName, 128);
        }
    }
}
