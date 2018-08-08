using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class AI_TargetS2C : GamePacket // 0x6A
    {
        public override GamePacketID ID => GamePacketID.AI_TargetS2C;
        public NetID TargetNetID { get; set; }
        public AI_TargetS2C(){}

        public AI_TargetS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
        }
    }
}
