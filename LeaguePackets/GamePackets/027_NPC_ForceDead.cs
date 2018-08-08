using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_ForceDead : GamePacket // 0x1B
    {
        public override GamePacketID ID => GamePacketID.NPC_ForceDead;
        public float DeathDuration { get; set; }
        public NPC_ForceDead(){}

        public NPC_ForceDead(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
