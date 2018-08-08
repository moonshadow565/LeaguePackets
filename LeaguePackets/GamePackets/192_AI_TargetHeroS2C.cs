using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class AI_TargetHeroS2C : GamePacket // 0xC0
    {
        public override GamePacketID ID => GamePacketID.AI_TargetHeroS2C;
        public NetID TargetNetID { get; set; }
        public static AI_TargetHeroS2C CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new AI_TargetHeroS2C();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TargetNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
        }
    }
}
