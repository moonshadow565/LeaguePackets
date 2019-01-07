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
        public QuestCommand Command { get; set; }
        public bool HandleRollovers { get; set; }
        public bool Ceremony { get; set; }
        public bool Success { get; set; }
        public QuestID QuestID { get; set; }

        public S2C_HandleQuestUpdate(){}

        public S2C_HandleQuestUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.ChannelID = channelID;
            this.SenderNetID = senderNetID;

            this.Objective = reader.ReadFixedString(128);
            this.Icon = reader.ReadFixedString(128);
            this.Tooltip = reader.ReadFixedString(128);
            this.Reward = reader.ReadFixedString(128);
            this.QuestType = reader.ReadQuestType();
            this.Command = reader.ReadQuestCommand();

            byte bitfield = reader.ReadByte();
            this.HandleRollovers = (bitfield & 0x01) != 0;
            this.Ceremony = (bitfield & 0x02) != 0;
            this.Success = (bitfield & 0x04) != 0;

            this.QuestID = reader.ReadQuestID();
            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(Objective, 128);
            writer.WriteFixedString(Icon, 128);
            writer.WriteFixedString(Tooltip, 128);
            writer.WriteFixedString(Reward, 128);
            writer.WriteQuestType(QuestType);
            writer.WriteQuestCommand(Command);

            byte bitfield = 0;
            if (HandleRollovers)
                bitfield |= 0x01;
            if (Ceremony)
                bitfield |= 0x02;
            if (Success)
                bitfield |= 0x04;
            writer.WriteByte(bitfield);

            writer.WriteQuestID(QuestID);
        }
    }

}
