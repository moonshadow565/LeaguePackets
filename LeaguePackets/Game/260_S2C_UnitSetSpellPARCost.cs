
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetSpellPARCost : GamePacket // 0x104
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetSpellPARCost;
        public byte CostType { get; set; }
        public int SpellSlot { get; set; }
        public float Amount { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.CostType = reader.ReadByte();
            this.SpellSlot = reader.ReadInt32();
            this.Amount = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(CostType);
            writer.WriteInt32(SpellSlot);
            writer.WriteFloat(Amount);
        }
    }
}
