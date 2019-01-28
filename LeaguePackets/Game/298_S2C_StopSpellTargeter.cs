
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_StopSpellTargeter : GamePacket // 0x12A
    {
        public override GamePacketID ID => GamePacketID.S2C_StopSpellTargeter;
        public byte Slot { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            Slot = (byte)reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32((uint)Slot);
        }
    }
}
