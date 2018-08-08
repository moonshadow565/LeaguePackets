using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UpdateAscended : GamePacket // 0x124
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateAscended;
        public NetID AscendedNetID { get; set; }
        public S2C_UpdateAscended(){}

        public S2C_UpdateAscended(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.AscendedNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(AscendedNetID);
        }
    }
}
