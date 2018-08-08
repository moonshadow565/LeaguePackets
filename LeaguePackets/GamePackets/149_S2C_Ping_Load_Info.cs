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
    public class S2C_Ping_Load_Info : GamePacket // 0x95
    {
        public override GamePacketID ID => GamePacketID.S2C_Ping_Load_Info;
        public ConnectionInfo ConnectionInfo { get; set; } = new ConnectionInfo();
        public S2C_Ping_Load_Info(){}

        public S2C_Ping_Load_Info(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ConnectionInfo = reader.ReadConnectionInfo();
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteConnectionInfo(ConnectionInfo);
        }
    }
}
