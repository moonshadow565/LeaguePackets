using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SetFadeOut_Push : GamePacket // 0xB2
    {
        public override GamePacketID ID => GamePacketID.SetFadeOut_Push;
        public short FadeId { get; set; }
        public float FadeTime { get; set; }
        public float FadeTargetValue { get; set; }
        public SetFadeOut_Push(){}

        public SetFadeOut_Push(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.FadeId = reader.ReadInt16();
            this.FadeTime = reader.ReadFloat();
            this.FadeTargetValue = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt16(FadeId);
            writer.WriteFloat(FadeTime);
            writer.WriteFloat(FadeTargetValue);
        }
    }
}
