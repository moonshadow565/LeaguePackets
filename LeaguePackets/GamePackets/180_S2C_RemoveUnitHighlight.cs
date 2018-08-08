using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_RemoveUnitHighlight : GamePacket // 0xB4
    {
        public override GamePacketID ID => GamePacketID.S2C_RemoveUnitHighlight;
        public NetID NetID { get; set; }
        public S2C_RemoveUnitHighlight(){}

        public S2C_RemoveUnitHighlight(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
        }
    }
}
