using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_StatsUpdateReq : GamePacket // 0x56
    {
        public override GamePacketID ID => GamePacketID.C2S_StatsUpdateReq;
        public static C2S_StatsUpdateReq CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new C2S_StatsUpdateReq();
            result.SenderNetID = senderNetID;
            reader.ReadPad(20);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePad(20);
        }
    }
}
