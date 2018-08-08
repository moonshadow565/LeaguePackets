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
        public S2C_UpdateDeathTimer(){}

        public S2C_UpdateDeathTimer(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.DeathDuration = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(DeathDuration);
        }
    }
}
