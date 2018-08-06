using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ReattachFollowerObject : GamePacket // 0xF2
    {
        public override GamePacketID ID => GamePacketID.S2C_ReattachFollowerObject;
        public NetID NewOwnerId { get; set; }
        public static S2C_ReattachFollowerObject CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_ReattachFollowerObject();
            result.SenderNetID = senderNetID;
            result.NewOwnerId = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NewOwnerId);
        }
    }
}
