using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class World_SendCamera_Server_Acknologment : GamePacket // 0x2C
    {
        public override GamePacketID ID => GamePacketID.World_SendCamera_Server_Acknologment;
        public byte SyncID { get; set; }
        public World_SendCamera_Server_Acknologment(){}

        public World_SendCamera_Server_Acknologment(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SyncID = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(SyncID);
        }
    }
}
