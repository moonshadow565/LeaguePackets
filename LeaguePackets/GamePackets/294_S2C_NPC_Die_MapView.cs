using LeaguePackets.Common;
using LeaguePackets.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_NPC_Die_MapView : GamePacket // 0x126
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_Die_MapView;
        public DeathDataPacket DeathData { get; set; } = new DeathDataPacket();
        public S2C_NPC_Die_MapView(){}

        public S2C_NPC_Die_MapView(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
