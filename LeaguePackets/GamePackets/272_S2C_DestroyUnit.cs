using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_DestroyUnit : GamePacket // 0x110
    {
        public override GamePacketID ID => GamePacketID.S2C_DestroyUnit;
        public static S2C_DestroyUnit CreateBody(PacketReader reader, NetID senderNetID) 
        {
            var result = new S2C_DestroyUnit();
            result.SenderNetID = senderNetID;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
