using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class FX_Kill : GamePacket // 0x38
    {
        public override GamePacketID ID => GamePacketID.FX_Kill;
        public NetID NetID { get; set; }
        public static FX_Kill CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new FX_Kill();
            result.SenderNetID = senderNetID;
            result.NetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
        }
    }
}
