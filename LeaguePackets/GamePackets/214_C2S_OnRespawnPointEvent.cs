using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_OnRespawnPointEvent : GamePacket // 0xD6
    {
        public override GamePacketID ID => GamePacketID.C2S_OnRespawnPointEvent;
        public RespawnPointEvent RespawnPointEvent { get; set; }
        public RespawnPointUIID RespawnPointUIElementID { get; set; }
        public static C2S_OnRespawnPointEvent CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new C2S_OnRespawnPointEvent();
            result.SenderNetID = senderNetID;
            result.RespawnPointEvent = reader.ReadRespawnPointEvent();
            result.RespawnPointUIElementID = reader.ReadRespawnPointUIID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteRespawnPointEvent(RespawnPointEvent);
            writer.WriteRespawnPointUIID(RespawnPointUIElementID);
        }
    }
}
