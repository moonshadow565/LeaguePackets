
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SystemMessage : GamePacket // 0xF7
    {
        public override GamePacketID ID => GamePacketID.S2C_SystemMessage;
        public uint SourceNetID { get; set; }
        public string Message { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.SourceNetID = reader.ReadUInt32();
            this.Message = reader.ReadFixedStringLast(512);
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(SourceNetID);
            writer.WriteFixedStringLast(Message, 512);
        }
    }
}
