using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_BotAI : GamePacket // 0x13
    {
        private string[] _states = new string[3];
        public override GamePacketID ID => GamePacketID.S2C_BotAI;
        public string AIName { get; set; } = "";
        public string AIStrategy { get; set; } = "";
        public string AIBehaviour { get; set; } = "";
        public string AITask { get; set; } = "";
        public string[] States => _states;
        public static S2C_BotAI CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_BotAI();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.AIName = reader.ReadFixedString(64);
            result.AIStrategy = reader.ReadFixedString(64);
            result.AIBehaviour = reader.ReadFixedString(64);
            result.AITask = reader.ReadFixedString(64);
            for (var i = 0; i < 3; i++)
            {
                result.States[i] = reader.ReadFixedString(64);
            }
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(AIName, 64);
            writer.WriteFixedString(AIStrategy, 64);
            writer.WriteFixedString(AIBehaviour, 64);
            writer.WriteFixedString(AITask, 64);
            for (var i = 0; i < 3; i++)
            {
                writer.WriteFixedString(_states[i], 64);
            }
        }
    }
}
