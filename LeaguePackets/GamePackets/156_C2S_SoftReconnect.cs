using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_SoftReconnect : GamePacket // 0x9C
    {
        public override GamePacketID ID => GamePacketID.C2S_SoftReconnect;
        public static C2S_SoftReconnect CreateBody(PacketReader reader, NetID senderNetID) 
        {
            var result = new C2S_SoftReconnect();
            result.SenderNetID = senderNetID;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
