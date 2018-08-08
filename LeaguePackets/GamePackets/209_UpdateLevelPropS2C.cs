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

        public UpdateLevelPropS2C(){}

        public UpdateLevelPropS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;
            this.UpdateLevelPropData = reader.ReadUpdateLevelPropData();
            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUpdateLevelPropData(UpdateLevelPropData);
        }
    }
}
