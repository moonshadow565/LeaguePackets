
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class AI_Command : GamePacket // 0x7A
    {
        public override GamePacketID ID => GamePacketID.AI_Command;
        public string Command { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.Command = reader.ReadFixedStringLast(128);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(Command, 128);
        }
    }
}
