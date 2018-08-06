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
        public static SendSelectedObjID CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new SendSelectedObjID();
            result.SenderNetID = senderNetID;
            result.ClientID = reader.ReadClientID();
            result.SelectedNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            writer.WriteNetID(SelectedNetID);
        }
    }
}
