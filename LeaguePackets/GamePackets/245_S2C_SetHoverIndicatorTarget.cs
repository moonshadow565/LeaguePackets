using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetHoverIndicatorTarget : GamePacket // 0xF5
    {
        public override GamePacketID ID => GamePacketID.S2C_SetHoverIndicatorTarget;
        public NetID TargetNetID { get; set; }
        public S2C_SetHoverIndicatorTarget(){}

        public S2C_SetHoverIndicatorTarget(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
