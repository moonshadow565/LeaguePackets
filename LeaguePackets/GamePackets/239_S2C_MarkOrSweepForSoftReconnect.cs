using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_MarkOrSweepForSoftReconnect : GamePacket // 0xEF
    {
        public override GamePacketID ID => GamePacketID.S2C_MarkOrSweepForSoftReconnect;
        public bool Unknown1 { get; set; }
        public S2C_MarkOrSweepForSoftReconnect(){}

        public S2C_MarkOrSweepForSoftReconnect(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Unknown1 = reader.ReadUInt32() == 1;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(Unknown1 ? 1u : 0u);
        }
    }
}
