
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_MessageToClient_Broadcast : GamePacket // 0x18
    {
        public override GamePacketID ID => GamePacketID.NPC_MessageToClient_Broadcast;

        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public int SlotNumber { get; set; }
        public bool IsError { get; set; }
        public byte ColorIndex { get; set; }
        public uint FloatTextType { get; set; }
        public string Message { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {
            this.Unknown1 = reader.ReadUInt32();
            this.Unknown2 = reader.ReadUInt32();
            this.SlotNumber = reader.ReadInt32();
            this.IsError = reader.ReadBool();
            this.ColorIndex = reader.ReadByte();
            this.FloatTextType = reader.ReadUInt32();
            this.Message = reader.ReadFixedStringLast(1024);
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(Unknown1);
            writer.WriteUInt32(Unknown2);
            writer.WriteInt32(SlotNumber);
            writer.WriteBool(IsError);
            writer.WriteByte(ColorIndex);
            writer.WriteUInt32(FloatTextType);
            writer.WriteFixedStringLast(Message, 1024);
        }
    }
}
