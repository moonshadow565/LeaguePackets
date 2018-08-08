using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetSpellPARCost : GamePacket // 0x104
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetSpellPARCost;
        public CostType CostType { get; set; }
        public int SpellSlot { get; set; }
        public float Amount { get; set; }
        public static S2C_UnitSetSpellPARCost CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_UnitSetSpellPARCost();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.CostType = reader.ReadCostType();
            result.SpellSlot = reader.ReadInt32();
            result.Amount = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteCostType(CostType);
            writer.WriteInt32(SpellSlot);
            writer.WriteFloat(Amount);
        }
    }
}
