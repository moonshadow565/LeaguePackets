using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetPARType : GamePacket // 0x113
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetPARType;
        public PARType PARType { get; set; }
        public S2C_UnitSetPARType(){}

        public S2C_UnitSetPARType(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.PARType = reader.ReadPARType();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePARType(PARType);
        }
    }
}
