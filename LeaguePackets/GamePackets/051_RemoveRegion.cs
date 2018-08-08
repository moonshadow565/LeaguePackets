using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class RemoveRegion : GamePacket // 0x33
    {
        public override GamePacketID ID => GamePacketID.RemoveRegion;
        public NetID RegionNetID { get; set; }
        public RemoveRegion(){}

        public RemoveRegion(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.RegionNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(RegionNetID);
        }
    }
}
