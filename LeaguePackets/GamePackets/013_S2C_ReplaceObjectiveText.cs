using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ReplaceObjectiveText : GamePacket // 0xD
    {
        public override GamePacketID ID => GamePacketID.S2C_ReplaceObjectiveText;
        public string TextID { get; set; } = "";
        public S2C_ReplaceObjectiveText(){}

        public S2C_ReplaceObjectiveText(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TextID = reader.ReadFixedStringLast(128);
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedStringLast(TextID, 128);
        }
    }
}
