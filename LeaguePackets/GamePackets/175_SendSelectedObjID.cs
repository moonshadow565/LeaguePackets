using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SendSelectedObjID : GamePacket // 0xAF
    {
        public override GamePacketID ID => GamePacketID.SendSelectedObjID;
        public ClientID ClientID { get; set; }
        public NetID SelectedNetID { get; set; }
        public SendSelectedObjID(){}

        public SendSelectedObjID(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ClientID = reader.ReadClientID();
            this.SelectedNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            writer.WriteNetID(SelectedNetID);
        }
    }
}
