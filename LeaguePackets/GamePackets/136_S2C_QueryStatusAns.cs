using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_QueryStatusAns : GamePacket // 0x88
    {
        public override GamePacketID ID => GamePacketID.S2C_QueryStatusAns;
        public bool Response { get; set; }
        public S2C_QueryStatusAns(){}

        public S2C_QueryStatusAns(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Response = reader.ReadBool();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(Response);
        }
    }
}
