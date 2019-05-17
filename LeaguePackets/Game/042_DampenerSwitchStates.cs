
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
        public byte State { get; set; }
        public ushort Duration { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.State = reader.ReadByte();
            this.Duration = reader.ReadUInt16();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(State);
            writer.WriteUInt16(Duration);
        }
    }
}
