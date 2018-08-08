using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_NotifyContextualSituation : GamePacket // 0x121
    {
        public override GamePacketID ID => GamePacketID.S2C_NotifyContextualSituation;
        public uint SituationNameHash { get; set; }
        public S2C_NotifyContextualSituation(){}

        public S2C_NotifyContextualSituation(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SituationNameHash = reader.ReadUInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(SituationNameHash);
        }
    }
}
