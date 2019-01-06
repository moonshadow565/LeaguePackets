using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_MessageToClient_MapView : GamePacket // 0x128
    {
        public override GamePacketID ID => GamePacketID.NPC_MessageToClient_MapView;
        public float BubbleDelay { get; set; }
        public int SlotNumber { get; set; }
        public bool IsError { get; set; }
        public byte ColorIndex { get; set; }
        public FloatTextType FloatingTextType { get; set; }
        public string Message { get; set; } = "";
        public NPC_MessageToClient_MapView(){}

        public NPC_MessageToClient_MapView(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.BubbleDelay = reader.ReadFloat();
            this.SlotNumber = reader.ReadInt32();
            this.IsError = reader.ReadBool();
            this.ColorIndex = reader.ReadByte();
            this.FloatingTextType = reader.ReadFloatTextType();
            this.Message = reader.ReadSizedFixedStringLast(1024);

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(BubbleDelay);
            writer.WriteInt32(SlotNumber);
            writer.WriteBool(IsError);
            writer.WriteByte(ColorIndex);
            writer.WriteFloatTextType(FloatingTextType);
            writer.WriteSizedFixedStringLast(Message, 1024);
        }
    }
}
