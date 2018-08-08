using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_WriteNavFlags_Acc : GamePacket // 0x1D
    {
        public override GamePacketID ID => GamePacketID.C2S_WriteNavFlags_Acc;
        public int SyncID { get; set; }
        public C2S_WriteNavFlags_Acc(){}

        public C2S_WriteNavFlags_Acc(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SyncID = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SyncID);
        }
    }
}
