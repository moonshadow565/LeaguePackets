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
        public static S2C_ModifyDebugText CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ModifyDebugText();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Text = reader.ReadSizedString();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteSizedString(Text);
        }
    }
}
