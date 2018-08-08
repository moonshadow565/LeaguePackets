using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PlayAnimation : GamePacket // 0xB0
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayAnimation;
        public AnimationFlags AnimationFlags { get; set; }
        public float ScaleTime { get; set; }
        public float StartProgress { get; set; }
        public float SpeedRatio { get; set; }
        public string AnimationName { get; set; } = "";
        public static S2C_PlayAnimation CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_PlayAnimation();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.AnimationFlags = reader.ReadAnimationFlags();
            result.ScaleTime = reader.ReadFloat();
            result.StartProgress = reader.ReadFloat();
            result.SpeedRatio = reader.ReadFloat();
            result.AnimationName = reader.ReadFixedString(64);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteAnimationFlags(AnimationFlags);
            writer.WriteFloat(ScaleTime);
            writer.WriteFloat(StartProgress);
            writer.WriteFloat(SpeedRatio);
            writer.WriteFixedString(AnimationName, 64);
        }
    }
}
