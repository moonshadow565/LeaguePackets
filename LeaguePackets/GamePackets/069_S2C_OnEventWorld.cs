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
    public class S2C_OnEventWorld : GamePacket // 0x45
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEventWorld;
        public Event Event { get; set; }

        public static S2C_OnEventWorld CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_OnEventWorld();
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
