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
        public static S2C_RefreshAuxiliaryText CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_RefreshAuxiliaryText();
            result.SenderNetID = senderNetID;
            result.MessageID = reader.ReadFixedString(128);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(MessageID, 128);
        }
    }
}
