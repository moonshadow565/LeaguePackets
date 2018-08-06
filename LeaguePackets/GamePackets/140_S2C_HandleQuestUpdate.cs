using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public abstract class S2C_HandleQuestUpdate : GamePacket // 0x8C
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleQuestUpdate;
        public string Objective { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Tooltip { get; set; } = "";
        public string Reward { get; set; } = "";
        public QuestType QuestType { get; set; }
        protected abstract QuestCommand QuestCommand { get; }
        protected abstract byte Bitfield { get; set; }
        public QuestID QuestID { get; set; }
        public static S2C_HandleQuestUpdate CreateBody(PacketReader reader, NetID senderNetID)
        {
            string objective = reader.ReadFixedString(128);
            string icon = reader.ReadFixedString(128);
            string tooltip = reader.ReadFixedString(128);
            string reward = reader.ReadFixedString(128);
            QuestType questType = reader.ReadQuestType();
            QuestCommand questCommand = reader.ReadQuestCommand();
            S2C_HandleQuestUpdate result;
            switch(questCommand)
            {
                case QuestCommand.Activate:
                    result = new S2C_HandleQuestUpdateActivate();
                    break;
                case QuestCommand.Complete:
                    result = new S2C_HandleQuestUpdateComplete();
                    break;
                case QuestCommand.Remove:
                    result = new S2C_HandleQuestUpdateRemove();
                    break;
                default:
                    result = new S2C_HandleQuestUpdateUnknown(questCommand);
                    break;
            }
            result.Bitfield = reader.ReadByte();
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
            writer.WriteQuestCommand(QuestCommand);
            writer.WriteByte(Bitfield);
            writer.WriteQuestID(QuestID);
        }
    }

    public class S2C_HandleQuestUpdateActivate : S2C_HandleQuestUpdate
    {
        protected override QuestCommand QuestCommand => QuestCommand.Activate;
        protected bool HandleRollovers { get; set; }
        protected bool Ceremony { get; set; }
        protected override byte Bitfield
        {
            get
            {
                byte bitfield = 0;
                if (HandleRollovers)
                {
                    bitfield |= 1;
                }
                if (Ceremony)
                {
                    bitfield |= 2;
                }
                return bitfield;
            }
            set
            {
                HandleRollovers = (value & 1) != 0;
                Ceremony = (value & 2) != 0;
            }
        }
    }

    public class S2C_HandleQuestUpdateComplete : S2C_HandleQuestUpdate
    {
        protected override QuestCommand QuestCommand => QuestCommand.Complete;
        protected bool Success { get; set; }
        protected override byte Bitfield
        {
            get
            {
                byte bitfield = 0;
                if (Success)
                {
                    bitfield |= 1;
                }
                return bitfield;
            }
            set
            {
                Success = (value & 1) != 0;
            }
        }
    }

    public class S2C_HandleQuestUpdateRemove : S2C_HandleQuestUpdate
    {
        protected override QuestCommand QuestCommand => QuestCommand.Remove;
        protected override byte Bitfield { get; set; }
    }

    public class S2C_HandleQuestUpdateUnknown : S2C_HandleQuestUpdate
    {
        private QuestCommand _questCommand;
        protected override QuestCommand QuestCommand => _questCommand;
        protected override byte Bitfield { get; set; }
        public byte BitfieldRaw
        {
            get => Bitfield;
            set => Bitfield = value;
        }
        public QuestCommand QuestCommandRaw 
        {
            get => _questCommand;
            set => _questCommand = value;
        }
        public S2C_HandleQuestUpdateUnknown(QuestCommand command) => _questCommand = command;
        public S2C_HandleQuestUpdateUnknown() {}
    }
}
