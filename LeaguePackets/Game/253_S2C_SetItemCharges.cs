
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetItemCharges : GamePacket // 0xFD
    {
        public override GamePacketID ID => GamePacketID.S2C_SetItemCharges;
        public byte Slot { get; set; }
        public byte SpellCharges { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Slot = reader.ReadByte();
            this.SpellCharges = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(SpellCharges);
        }
    }
}
