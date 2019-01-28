
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_OnQuestEvent : GamePacket // 0xCD
    {
        public override GamePacketID ID => GamePacketID.C2S_OnQuestEvent;
        public byte QuestEvent { get; set; }
        public uint QuestID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.QuestEvent = reader.ReadByte();
            this.QuestID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(QuestEvent);
            writer.WriteUInt32(QuestID);
        }
    }
}
