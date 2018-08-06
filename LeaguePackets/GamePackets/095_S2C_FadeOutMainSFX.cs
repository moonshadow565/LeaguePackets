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
        public static S2C_FadeOutMainSFX CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_FadeOutMainSFX();
            result.SenderNetID = senderNetID;
            result.FadeTime = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(FadeTime);
        }
    }
}
