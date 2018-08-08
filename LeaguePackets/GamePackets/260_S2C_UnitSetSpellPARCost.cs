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
        public S2C_UnitSetSpellPARCost(){}

        public S2C_UnitSetSpellPARCost(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.CostType = reader.ReadCostType();
            this.SpellSlot = reader.ReadInt32();
            this.Amount = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteCostType(CostType);
            writer.WriteInt32(SpellSlot);
            writer.WriteFloat(Amount);
        }
    }
}
