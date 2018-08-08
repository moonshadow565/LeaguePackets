using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_IncrementMinionKills : GamePacket // 0x11F
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementMinionKills;
        public NetID PlayerNetID { get; set; }
        public S2C_IncrementMinionKills(){}

        public S2C_IncrementMinionKills(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.PlayerNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(PlayerNetID);
        }
    }
}
