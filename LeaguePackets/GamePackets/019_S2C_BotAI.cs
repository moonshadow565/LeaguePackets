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
        public S2C_BotAI(){}

        public S2C_BotAI(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.AIName = reader.ReadFixedString(64);
            this.AIStrategy = reader.ReadFixedString(64);
            this.AIBehaviour = reader.ReadFixedString(64);
            this.AITask = reader.ReadFixedString(64);
            for (var i = 0; i < 3; i++)
            {
                this.States[i] = reader.ReadFixedString(64);
            }
            this.ExtraBytes = reader.ReadLeft();
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
