
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ModifyDebugText : GamePacket, IUnusedPacket // 0xE7
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugText;
        public int DebugID { get; set; }
        public string Text { get; set; } = "";
        public bool Unknown { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            this.DebugID = reader.ReadInt32();
            this.Text = reader.ReadFixedString(128);

            byte bitfield = reader.ReadByte();
            this.Unknown = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(DebugID);
            writer.WriteFixedString(Text, 128);

            byte bitfield = 0;
            if (Unknown)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
