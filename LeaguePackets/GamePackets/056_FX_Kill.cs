using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class FX_Kill : GamePacket // 0x38
    {
        public override GamePacketID ID => GamePacketID.FX_Kill;
        public NetID NetID { get; set; }
        public FX_Kill(){}

        public FX_Kill(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
