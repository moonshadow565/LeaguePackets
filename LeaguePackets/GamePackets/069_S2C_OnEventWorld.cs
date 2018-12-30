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

        public S2C_OnEventWorld(){}

        public S2C_OnEventWorld(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Event = reader.ReadEvent();

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteEvent(Event);
        }
    }
}
