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
        public static SyncMissionStartTimeS2C CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new SyncMissionStartTimeS2C();
            result.SenderNetID = senderNetID;
            result.StartTime = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(StartTime);
        }
    }
}
