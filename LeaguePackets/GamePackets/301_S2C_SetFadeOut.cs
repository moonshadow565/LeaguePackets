using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetFadeOut : GamePacket, IUnusedPacket // 0x12D
    {
        public override GamePacketID ID => GamePacketID.S2C_SetFadeOut;
        public float FadeTime { get; set; }
        public float FadeTargetValue { get; set; }
        public S2C_SetFadeOut(){}

        public S2C_SetFadeOut(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.FadeTime = reader.ReadFloat();
            this.FadeTargetValue = reader.ReadFloat();

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(FadeTime);
            writer.WriteFloat(FadeTargetValue);
        }
    }
}
