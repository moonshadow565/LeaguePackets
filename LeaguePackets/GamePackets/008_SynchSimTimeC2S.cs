using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SynchSimTimeC2S : GamePacket // 0x8
    {
        public override GamePacketID ID => GamePacketID.SynchSimTimeC2S;
        public float TimeLastServer { get; set; }
        public float TimeLastClient { get; set; }
        public SynchSimTimeC2S(){}

        public SynchSimTimeC2S(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TimeLastServer = reader.ReadFloat();
            this.TimeLastClient = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(TimeLastServer);
            writer.WriteFloat(TimeLastClient);
        }
    }
}
