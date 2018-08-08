using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class OnEvent : GamePacket // 0xA3
    {
        public override GamePacketID ID => GamePacketID.OnEvent;
        public Event Event { get; set; }
        public OnEvent(){}

        public OnEvent(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Event = Event.Create(reader);
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            Event.Write(writer);
        }
    }
}
