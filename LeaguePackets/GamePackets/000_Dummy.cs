using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Dummy : GamePacket // 0x0
    {
        public override GamePacketID ID => GamePacketID.Dummy;
        public Dummy(){}

        public Dummy(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;
            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
