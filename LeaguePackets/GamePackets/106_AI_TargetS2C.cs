using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class AI_TargetS2C : GamePacket // 0x6A
    {
        public override GamePacketID ID => GamePacketID.AI_TargetS2C;
        public NetID TargetNetID { get; set; }
        public static AI_TargetS2C CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new AI_TargetS2C();
            result.SenderNetID = senderNetID;
            result.TargetNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
        }
    }
}
