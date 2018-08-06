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
        public static OnEvent CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new OnEvent();
            result.SenderNetID = senderNetID;
            result.Event = Event.Create(reader);
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            Event.Write(writer);
        }
    }
}
