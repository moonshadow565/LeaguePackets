
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_UpgradeSpellAns : GamePacket // 0x15
    {
        public override GamePacketID ID => GamePacketID.NPC_UpgradeSpellAns;
        public byte Slot { get; set; }
        public byte SpellLevel { get; set; }
        public byte SkillPoints { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Slot = reader.ReadByte();
            this.SpellLevel = reader.ReadByte();
            this.SkillPoints = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(SpellLevel);
            writer.WriteByte(SkillPoints);
        }
    }
}
