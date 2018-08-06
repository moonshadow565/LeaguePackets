using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UpdateDeathTimer : GamePacket // 0x117
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateDeathTimer;
        public float DeathDuration { get; set; }
        public static S2C_UpdateDeathTimer CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_UpdateDeathTimer();
            result.SenderNetID = senderNetID;
            result.DeathDuration = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(DeathDuration);
        }
    }
}
