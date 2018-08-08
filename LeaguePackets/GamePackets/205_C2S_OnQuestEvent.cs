using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_OnQuestEvent : GamePacket // 0xCD
    {
        public override GamePacketID ID => GamePacketID.C2S_OnQuestEvent;
        public QuestEvent QuestEvent { get; set; }
        public QuestID QuestID { get; set; }
        public C2S_OnQuestEvent(){}

        public C2S_OnQuestEvent(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.QuestEvent = reader.ReadQuestEvent();
            this.QuestID = reader.ReadQuestID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteQuestEvent(QuestEvent);
            writer.WriteQuestID(QuestID);
        }
    }
}
