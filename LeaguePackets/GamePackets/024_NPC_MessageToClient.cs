using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_MessageToClient : GamePacket // 0x18
    {
        public override GamePacketID ID => GamePacketID.NPC_MessageToClient;

        public float BubbleDelay { get; set; }
        int SlotNumber { get; set; }
        bool IsError { get; set; }
        byte ColorIndex { get; set; }
        public FloatTextType FloatingTextType { get; set; }
        public string Message { get; set; } = "";


        public static NPC_MessageToClient CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_MessageToClient();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.BubbleDelay = reader.ReadFloat();
            result.SlotNumber = reader.ReadInt32();
            result.IsError = reader.ReadBool();
            result.ColorIndex = reader.ReadByte();
            result.FloatingTextType = reader.ReadFloatTextType();
            result.Message = reader.ReadSizedFixedString(1024);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(BubbleDelay);
            writer.WriteInt32(SlotNumber);
            writer.WriteBool(IsError);
            writer.WriteByte(ColorIndex);
            writer.WriteFloatTextType(FloatingTextType);
            writer.WriteSizedFixedString(Message, 1024);
        }
    }
}
