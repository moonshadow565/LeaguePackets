using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class ReplayOnly_GoldEarned : GamePacket // 0xE4
    {
        public override GamePacketID ID => GamePacketID.ReplayOnly_GoldEarned;
        public NetID OwnerID { get; set; }
        public float Amount { get; set; }
        public static ReplayOnly_GoldEarned CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new ReplayOnly_GoldEarned();
            result.SenderNetID = senderNetID;
            result.OwnerID = reader.ReadNetID();
            result.Amount = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(OwnerID);
            writer.WriteFloat(Amount);
        }
    }
}
