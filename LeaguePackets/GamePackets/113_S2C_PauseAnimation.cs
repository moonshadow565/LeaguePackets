using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PauseAnimation : GamePacket // 0x71
    {
        public override GamePacketID ID => GamePacketID.S2C_PauseAnimation;
        public bool Pause { get; set; }
        public static S2C_PauseAnimation CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_PauseAnimation();
            result.SenderNetID = senderNetID;
            byte bitfield = reader.ReadByte();
            result.Pause = (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Pause)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
