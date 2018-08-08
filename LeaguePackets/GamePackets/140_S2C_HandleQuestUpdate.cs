using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class S2C_HandleQuestUpdate : GamePacket // 0x8C
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleQuestUpdate;
        public string Objective { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Tooltip { get; set; } = "";
        public string Reward { get; set; } = "";
        public QuestType QuestType { get; set; }
        public IQuestUpdateData QuestUpdateData { get; set; }
        public QuestID QuestID { get; set; }

        public static S2C_HandleQuestUpdate CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_HandleQuestUpdate();
            result.ChannelID = channelID;
            result.SenderNetID = senderNetID;

            result.Objective = reader.ReadFixedString(128);
            result.Icon = reader.ReadFixedString(128);
            result.Tooltip = reader.ReadFixedString(128);
            result.Reward = reader.ReadFixedString(128);
            result.QuestType = reader.ReadQuestType();
            result.QuestUpdateData = reader.ReadQuestUpdateData();
            result.QuestID = reader.ReadQuestID();
            return result;
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(Objective, 128);
            writer.WriteFixedString(Icon, 128);
            writer.WriteFixedString(Tooltip, 128);
            writer.WriteFixedString(Reward, 128);
            writer.WriteQuestType(QuestType);
            writer.WriteQuestUpdateData(QuestUpdateData);
            writer.WriteQuestID(QuestID);
        }
    }

}
