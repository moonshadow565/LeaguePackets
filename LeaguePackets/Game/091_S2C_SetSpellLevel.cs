
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetSpellLevel : GamePacket // 0x5B
    {
        public override GamePacketID ID => GamePacketID.S2C_SetSpellLevel;
        public int SpellSlot { get; set; }
        public int SpellLevel { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SpellSlot = reader.ReadInt32();
            this.SpellLevel = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SpellSlot);
            writer.WriteInt32(SpellLevel);
        }
    }
}
