
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
        public string Text { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.Text = reader.ReadSizedString();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteSizedString(Text);
        }
    }
}
