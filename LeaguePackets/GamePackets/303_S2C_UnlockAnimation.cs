using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnlockAnimation : GamePacket // 0x12F
    {
        public override GamePacketID ID => GamePacketID.S2C_UnlockAnimation;
        public string AnimationName { get; set; } = "";
        public S2C_UnlockAnimation(){}

        public S2C_UnlockAnimation(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.AnimationName = reader.ReadFixedStringLast(64);

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedStringLast(AnimationName, 64);
        }
    }
}
