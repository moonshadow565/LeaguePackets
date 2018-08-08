using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_AnimationUpdateTimeStep : GamePacket // 0x103
    {
        public override GamePacketID ID => GamePacketID.S2C_AnimationUpdateTimeStep;
        public float UpdateTimeStep { get; set; }
        public string AnimationName { get; set; } = "";
        public S2C_AnimationUpdateTimeStep(){}

        public S2C_AnimationUpdateTimeStep(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.UpdateTimeStep = reader.ReadFloat();
            this.AnimationName = reader.ReadFixedStringLast(64);
            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(UpdateTimeStep);
            writer.WriteFixedStringLast(AnimationName, 64);
        }
    }
}
