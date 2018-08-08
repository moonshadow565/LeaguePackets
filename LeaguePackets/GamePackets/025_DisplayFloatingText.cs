using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class DisplayFloatingText : GamePacket // 0x19
    {
        public override GamePacketID ID => GamePacketID.DisplayFloatingText;
        public NetID TargetNetID { get; set; }

        public FloatTextType FloatingTextType { get; set; }
        public int Param { get; set; }
        public string Message { get; set; } = "";
        public DisplayFloatingText(){}

        public DisplayFloatingText(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetNetID = reader.ReadNetID();
            this.FloatingTextType = reader.ReadFloatTextType();
            this.Param = reader.ReadInt32();
            this.Message = reader.ReadFixedStringLast(128);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteFloatTextType(FloatingTextType);
            writer.WriteInt32(Param);
            writer.WriteFixedStringLast(Message, 128);
        }
    }
}
