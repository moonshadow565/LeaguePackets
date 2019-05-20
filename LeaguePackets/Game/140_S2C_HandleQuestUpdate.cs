
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class S2C_HandleQuestUpdate : GamePacket // 0x8C
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleQuestUpdate;
        public string Objective { get; set; } = "";
        public string Tooltip { get; set; } = "";
        public string Reward { get; set; } = "";
        public byte QuestType { get; set; }
        public byte QuestCommand { get; set; }
        public bool HandleRollovers { get; set; }
        public uint QuestID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Objective = reader.ReadFixedString(128);
            this.Tooltip = reader.ReadFixedString(128);
            this.Reward = reader.ReadFixedString(128);
            this.QuestType = reader.ReadByte();
            this.QuestCommand = reader.ReadByte();

            byte bitfield = reader.ReadByte();
            this.HandleRollovers = (bitfield & 0x01) != 0;

            this.QuestID = reader.ReadUInt32();
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(Objective, 128);
            writer.WriteFixedString(Tooltip, 128);
            writer.WriteFixedString(Reward, 128);
            writer.WriteByte(QuestType);
            writer.WriteByte(QuestCommand);

            byte bitfield = 0;
            if (HandleRollovers)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);

            writer.WriteUInt32(QuestID);
        }
    }

}
