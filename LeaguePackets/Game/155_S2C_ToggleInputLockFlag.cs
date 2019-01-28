
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ToggleInputLockFlag : GamePacket // 0x9B
    {
        public override GamePacketID ID => GamePacketID.S2C_ToggleInputLockFlag;
        public uint InputLockFlags { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.InputLockFlags = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(InputLockFlags);
        }
    }
}
