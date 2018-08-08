using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class NPC_Die : GamePacket // 0x9E
    {
        public override GamePacketID ID => GamePacketID.NPC_Die;
        public DeathDataPacket DeathData { get; set; } = new DeathDataPacket();
        public NPC_Die(){}

        public NPC_Die(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.DeathData = reader.ReadDeathDataPacket();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteDeathDataPacket(DeathData);
        }
    }
}
