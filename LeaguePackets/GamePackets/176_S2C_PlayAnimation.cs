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
        //TODO: figure out this stupid bitfield
        public byte AnimationFlags { get; set; }
        public float ScaleTime { get; set; }
        public float StartProgress { get; set; }
        public float SpeedRatio { get; set; }
        public string AnimationName { get; set; } = "";

        public S2C_PlayAnimation(){}

        public S2C_PlayAnimation(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.AnimationFlags = reader.ReadByte();
            this.ScaleTime = reader.ReadFloat();
            this.StartProgress = reader.ReadFloat();
            this.SpeedRatio = reader.ReadFloat();
            this.AnimationName = reader.ReadFixedStringLast(64);
            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(AnimationFlags);
            writer.WriteFloat(ScaleTime);
            writer.WriteFloat(StartProgress);
            writer.WriteFloat(SpeedRatio);
            writer.WriteFixedStringLast(AnimationName, 64);
        }
    }
}
