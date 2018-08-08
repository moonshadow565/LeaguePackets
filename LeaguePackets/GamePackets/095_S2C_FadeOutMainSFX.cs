using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_FadeOutMainSFX : GamePacket // 0x5F
    {
        public override GamePacketID ID => GamePacketID.S2C_FadeOutMainSFX;
        public float FadeTime { get; set; }
        public S2C_FadeOutMainSFX(){}

        public S2C_FadeOutMainSFX(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.FadeTime = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(FadeTime);
        }
    }
}
