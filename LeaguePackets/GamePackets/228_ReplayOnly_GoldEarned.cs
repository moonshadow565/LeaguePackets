using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class ReplayOnly_GoldEarned : GamePacket // 0xE4
    {
        public override GamePacketID ID => GamePacketID.ReplayOnly_GoldEarned;
        public NetID OwnerID { get; set; }
        public float Amount { get; set; }
        public ReplayOnly_GoldEarned(){}

        public ReplayOnly_GoldEarned(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.OwnerID = reader.ReadNetID();
            this.Amount = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(OwnerID);
            writer.WriteFloat(Amount);
        }
    }
}
