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
        public C2S_OnRespawnPointEvent(){}

        public C2S_OnRespawnPointEvent(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.RespawnPointEvent = reader.ReadRespawnPointEvent();
            this.RespawnPointUIElementID = reader.ReadRespawnPointUIID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteRespawnPointEvent(RespawnPointEvent);
            writer.WriteRespawnPointUIID(RespawnPointUIElementID);
        }
    }
}
