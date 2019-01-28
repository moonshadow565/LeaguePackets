
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetUndoEnabled : GamePacket // 0x10B
    {
        public override GamePacketID ID => GamePacketID.S2C_SetUndoEnabled;
        public byte UndoStackSize { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.UndoStackSize = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(UndoStackSize);
        }
    }
}
