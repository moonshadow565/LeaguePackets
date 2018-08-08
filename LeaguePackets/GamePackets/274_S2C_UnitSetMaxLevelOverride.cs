using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetMaxLevelOverride : GamePacket // 0x112
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetMaxLevelOverride;
        public byte MaxLevelOverride { get; set; }
        public S2C_UnitSetMaxLevelOverride(){}

        public S2C_UnitSetMaxLevelOverride(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.MaxLevelOverride = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(MaxLevelOverride);
        }
    }
}
