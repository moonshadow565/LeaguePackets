using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_RefreshAuxiliaryText : GamePacket // 0xB1
    {
        public override GamePacketID ID => GamePacketID.S2C_RefreshAuxiliaryText;
        public string MessageID { get; set; } = "";

        public S2C_RefreshAuxiliaryText() {}

        public S2C_RefreshAuxiliaryText(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.MessageID = reader.ReadFixedStringLast(128);
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedStringLast(MessageID, 128);
        }
    }
}
