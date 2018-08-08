using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SpectatorMetaData : GamePacket // 0xEB
    {
        public override GamePacketID ID => GamePacketID.S2C_SpectatorMetaData;
        public string JsonMetaData { get; set; } = "";
        public S2C_SpectatorMetaData(){}

        public S2C_SpectatorMetaData(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.JsonMetaData = reader.ReadSizedString();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteSizedString(JsonMetaData);
        }
    }
}
