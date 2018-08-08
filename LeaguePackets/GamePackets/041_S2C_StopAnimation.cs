using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_StopAnimation : GamePacket // 0x29
    {
        public override GamePacketID ID => GamePacketID.S2C_StopAnimation;
        public bool Fade { get; set; }
        public bool Unlock { get; set; }
        public bool StopAll { get; set; }
        public string AnimationName { get; set; } = "";
        public S2C_StopAnimation(){}

        public S2C_StopAnimation(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte flags = reader.ReadByte();
            this.Fade = (flags & 1) != 0;
            this.Unlock = (flags & 2) != 0;
            this.StopAll = (flags & 4) != 0;
            this.AnimationName = reader.ReadFixedString(64);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte flags = 0;
            if (Fade)
                flags |= 1;
            if (Unlock)
                flags |= 2;
            if (StopAll)
                flags |= 4;
            writer.WriteByte(flags);
            writer.WriteFixedString(AnimationName, 64);
        }
    }
}
