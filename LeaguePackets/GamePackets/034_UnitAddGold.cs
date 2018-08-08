using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UnitAddGold : GamePacket // 0x22
    {
        public override GamePacketID ID => GamePacketID.UnitAddGold;
        public NetID TargetNetID { get; set; }
        public NetID SourceNetID { get; set; }
        public float GoldAmmount { get; set; }
        public UnitAddGold(){}

        public UnitAddGold(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetNetID = reader.ReadNetID();
            this.SourceNetID = reader.ReadNetID();
            this.GoldAmmount = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteNetID(SourceNetID);
            writer.WriteFloat(GoldAmmount);
        }
    }
}
