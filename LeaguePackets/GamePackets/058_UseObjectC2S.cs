using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UseObjectC2S : GamePacket // 0x3A
    {
        public override GamePacketID ID => GamePacketID.UseObjectC2S;
        public NetID TargetNetID { get; set; }
        public static UseObjectC2S CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new UseObjectC2S();
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
