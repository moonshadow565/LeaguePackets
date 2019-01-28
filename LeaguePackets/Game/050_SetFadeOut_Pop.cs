
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SetFadeOut_Pop : GamePacket // 0x32
    {
        public override GamePacketID ID => GamePacketID.SetFadeOut_Pop;
        public short StackID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.StackID = reader.ReadInt16();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt16(StackID);
        }
    }
}
