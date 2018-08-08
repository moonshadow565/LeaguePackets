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
        public static S2C_UnitSetMaxLevelOverride CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_UnitSetMaxLevelOverride();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.MaxLevelOverride = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(MaxLevelOverride);
        }
    }
}
