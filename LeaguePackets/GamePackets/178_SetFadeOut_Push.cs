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
        public static SetFadeOut_Push CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SetFadeOut_Push();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.FadeId = reader.ReadInt16();
            result.FadeTime = reader.ReadFloat();
            result.FadeTargetValue = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt16(FadeId);
            writer.WriteFloat(FadeTime);
            writer.WriteFloat(FadeTargetValue);
        }
    }
}
