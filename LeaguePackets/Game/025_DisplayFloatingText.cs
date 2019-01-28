
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class DisplayFloatingText : GamePacket // 0x19
    {
        public override GamePacketID ID => GamePacketID.DisplayFloatingText;
        public uint TargetNetID { get; set; }

        public uint FloatTextType { get; set; }
        public int Param { get; set; }
        public string Message { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.TargetNetID = reader.ReadUInt32();
            this.FloatTextType = reader.ReadUInt32();
            this.Param = reader.ReadInt32();
            this.Message = reader.ReadFixedStringLast(128);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TargetNetID);
            writer.WriteUInt32(FloatTextType);
            writer.WriteInt32(Param);
            writer.WriteFixedStringLast(Message, 128);
        }
    }
}
