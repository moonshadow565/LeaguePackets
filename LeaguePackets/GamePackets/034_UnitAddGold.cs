using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UnitAddGold : GamePacket // 0x22
    {
        public override GamePacketID ID => GamePacketID.UnitAddGold;
        public NetID TargetNetID { get; set; }
        public NetID SourceNetID { get; set; }
        public float GoldAmmount { get; set; }
        public static UnitAddGold CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new UnitAddGold();
            result.SenderNetID = senderNetID;
            result.TargetNetID = reader.ReadNetID();
            result.SourceNetID = reader.ReadNetID();
            result.GoldAmmount = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteNetID(SourceNetID);
            writer.WriteFloat(GoldAmmount);
        }
    }
}
