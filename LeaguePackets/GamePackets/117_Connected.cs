using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Connected : GamePacket // 0x75
    {
        public override GamePacketID ID => GamePacketID.Connected;
        public ClientID ClientID { get; set; }
        public Connected(){}

        public Connected(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ClientID = reader.ReadClientID();
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
        }
    }
}
