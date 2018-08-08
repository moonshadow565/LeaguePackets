using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_StartSpawn : GamePacket // 0x62
    {
        public override GamePacketID ID => GamePacketID.S2C_StartSpawn;
        public byte BotCountOrder { get; set; }
        public byte BotCountChaos { get; set; }
        public static S2C_StartSpawn CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_StartSpawn();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.BotCountOrder = reader.ReadByte();
            result.BotCountChaos = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(BotCountOrder);
            writer.WriteByte(BotCountChaos);
        }
    }
}
