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
        public static S2C_ReplaceObjectiveText CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_ReplaceObjectiveText();
            result.SenderNetID = senderNetID;
            result.TextID = reader.ReadFixedString(128);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(TextID, 128);
        }
    }
}
