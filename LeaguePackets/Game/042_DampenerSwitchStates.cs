
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class DampenerSwitchStates : GamePacket // 0x2B
    {
        public override GamePacketID ID => GamePacketID.DampenerSwitchStates;

        public ushort Duration { get; set; }
        public bool State { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            ushort bitfield = reader.ReadUInt16();
            this.Duration = (ushort)(bitfield & 0x7FFFu);
            this.State = (bitfield & 0x8000) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            ushort bitfield = 0;
            bitfield |= (ushort)(Duration & 0x7FFFu);
            if (State)
                bitfield |= 0x8000;
            writer.WriteUInt16(bitfield);
        }
    }
}
