using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class OnReplication_Acc : GamePacket // 0xA8
    {
        public override GamePacketID ID => GamePacketID.OnReplication_Acc;
        public uint SyncID { get; set; }
        public OnReplication_Acc(){}

        public OnReplication_Acc(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SyncID = reader.ReadUInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(SyncID);
        }
    }
}
