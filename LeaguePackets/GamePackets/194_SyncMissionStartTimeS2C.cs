using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SyncMissionStartTimeS2C : GamePacket // 0xC2
    {
        public override GamePacketID ID => GamePacketID.SyncMissionStartTimeS2C;
        public float StartTime { get; set; }
        public SyncMissionStartTimeS2C(){}

        public SyncMissionStartTimeS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.StartTime = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(StartTime);
        }
    }
}
