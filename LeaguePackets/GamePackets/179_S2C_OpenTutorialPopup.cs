using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_OpenTutorialPopup : GamePacket // 0xB3
    {
        public override GamePacketID ID => GamePacketID.S2C_OpenTutorialPopup;
        public string MessageboxID { get; set; } = "";
        public static S2C_OpenTutorialPopup CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_OpenTutorialPopup();
            result.SenderNetID = senderNetID;
            result.MessageboxID = reader.ReadFixedString(128);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(MessageboxID, 128);
        }
    }
}
