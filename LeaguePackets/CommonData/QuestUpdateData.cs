using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public interface IQuestUpdateData
    {
        QuestCommand QuestCommand { get; }
        byte Bitfield { get; set; }
    }

    public static class QuestUpdateDataExtension 
    {
        public static IQuestUpdateData ReadQuestUpdateData(this PacketReader reader)
        {
            QuestCommand questCommand = reader.ReadQuestCommand();
            IQuestUpdateData result;
            switch (questCommand)
            {
                case QuestCommand.Activate:
                    result = new QuestUpdateDataActivate();
                    break;
                case QuestCommand.Complete:
                    result = new QuestUpdateDataComplete();
                    break;
                case QuestCommand.Remove:
                    result = new QuestUpdateDataRemove();
                    break;
                default:
                    result = new QuestUpdateDataUnknown
                    {
                        QuestCommand = questCommand
                    };
                    break;
            }
            result.Bitfield = reader.ReadByte();
            return result;
        }

        public static void WriteQuestUpdateData(this PacketWriter writer, IQuestUpdateData data)
        {
            writer.WriteQuestCommand(data.QuestCommand);
            writer.WriteByte(data.Bitfield);
        }
    }

    public class QuestUpdateDataActivate : IQuestUpdateData
    {
        public QuestCommand QuestCommand => QuestCommand.Activate;
        public bool HandleRollovers { get; set; }
        public bool Ceremony { get; set; }
        public byte Bitfield
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

    public class QuestUpdateDataComplete : IQuestUpdateData
    {
        public QuestCommand QuestCommand => QuestCommand.Complete;
        public bool Success { get; set; }
        public byte Bitfield
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

    public class QuestUpdateDataRemove : IQuestUpdateData
    {
        public QuestCommand QuestCommand => QuestCommand.Remove;
        public byte Bitfield { get; set; }
    }

    public class QuestUpdateDataUnknown : IQuestUpdateData
    {
        public QuestCommand QuestCommand { get; set; }
        public byte Bitfield { get; set; }
    }
}
