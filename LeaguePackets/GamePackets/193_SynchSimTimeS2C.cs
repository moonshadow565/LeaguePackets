using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SynchSimTimeS2C : GamePacket // 0xC1
    {
        public override GamePacketID ID => GamePacketID.SynchSimTimeS2C;
        public float SynchTime { get; set; }
        public SynchSimTimeS2C(){}

        public SynchSimTimeS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SynchTime = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(SynchTime);
        }
    }
}
