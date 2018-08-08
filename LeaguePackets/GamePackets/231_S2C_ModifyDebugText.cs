using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ModifyDebugText : GamePacket, IUnusedPacket // 0xE7
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugText;
        public string Text { get; set; } = "";
        public S2C_ModifyDebugText(){}

        public S2C_ModifyDebugText(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Text = reader.ReadSizedString();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteSizedString(Text);
        }
    }
}
