
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetSpellData : GamePacket // 0x70
    {
        public override GamePacketID ID => GamePacketID.S2C_SetSpellData;
        public uint ObjectNetID { get; set; }
        public uint HashedSpellName { get; set; }
        public byte SpellSlot { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ObjectNetID = reader.ReadUInt32();
            this.HashedSpellName = reader.ReadUInt32();
            this.SpellSlot = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(ObjectNetID);
            writer.WriteUInt32(HashedSpellName);
            writer.WriteByte(SpellSlot);
        }
    }
}
