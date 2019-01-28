
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_UpdateGameOptions : GamePacket // 0x47
    {
        public override GamePacketID ID => GamePacketID.C2S_UpdateGameOptions;
        public bool AutoAttackEnabled { get;set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.AutoAttackEnabled = (bitfield & 0x01) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (AutoAttackEnabled)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
