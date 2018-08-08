using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SyncSimTimeFinalS2C : GamePacket // 0x76
    {
        public override GamePacketID ID => GamePacketID.SyncSimTimeFinalS2C;
        public float TimeLastClient { get; set; }
        public float TimeRTTLastOverhead { get; set; }
        public float TimeConvergance { get; set; }
        public SyncSimTimeFinalS2C(){}

        public SyncSimTimeFinalS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TimeLastClient = reader.ReadFloat();
            this.TimeRTTLastOverhead = reader.ReadFloat();
            this.TimeConvergance = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(TimeLastClient);
            writer.WriteFloat(TimeRTTLastOverhead);
            writer.WriteFloat(TimeConvergance);
        }
    }
}
