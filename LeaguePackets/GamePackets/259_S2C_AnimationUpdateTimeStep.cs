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
        public static S2C_AnimationUpdateTimeStep CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_AnimationUpdateTimeStep();
            result.SenderNetID = senderNetID;
            result.UpdateTimeStep = reader.ReadFloat();
            result.AnimationName = reader.ReadFixedString(64);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(UpdateTimeStep);
            writer.WriteFixedString(AnimationName, 64);
        }
    }
}
