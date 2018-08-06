using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_HideObjectiveText : GamePacket // 0xA2
    {
        public override GamePacketID ID => GamePacketID.S2C_HideObjectiveText;
        public static S2C_HideObjectiveText CreateBody(PacketReader reader, NetID senderNetID) 
        {
            var result = new S2C_HideObjectiveText();
            result.SenderNetID = senderNetID;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
