using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UpdateRestrictedChatCount : GamePacket // 0xF9
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateRestrictedChatCount;
        public int Count { get; set; }
        public S2C_UpdateRestrictedChatCount(){}

        public S2C_UpdateRestrictedChatCount(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Count = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(Count);
        }
    }
}
