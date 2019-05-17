
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_UpgradeSpellReq : GamePacket // 0x39
    {
        public override GamePacketID ID => GamePacketID.NPC_UpgradeSpellReq;
        public byte Slot { get; set; }
        public bool IsEvolve { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Slot = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.IsEvolve = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);
            byte bitfield = 0;
            if (IsEvolve)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
