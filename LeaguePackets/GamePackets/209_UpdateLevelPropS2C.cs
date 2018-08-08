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
    public class UpdateLevelPropS2C : GamePacket // 0xD1
    {
        public override GamePacketID ID => GamePacketID.UpdateLevelPropS2C;
        public UpdateLevelPropData UpdateLevelPropData { get; set; }

        public static UpdateLevelPropS2C CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new UpdateLevelPropS2C();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;
            result.UpdateLevelPropData = reader.ReadUpdateLevelPropData();
            return result;
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUpdateLevelPropData(UpdateLevelPropData);
        }
    }
}
