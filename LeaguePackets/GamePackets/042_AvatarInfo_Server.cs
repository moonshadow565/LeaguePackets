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
    public class AvatarInfo_Server : GamePacket // 0x2A
    {
        public override GamePacketID ID => GamePacketID.AvatarInfo_Server;
        public AvatarInfo AvatarInfo { get; set; } = new AvatarInfo();

        public AvatarInfo_Server(){}

        public AvatarInfo_Server(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.AvatarInfo = reader.ReadAvatarInfo();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteAvatarInfo(AvatarInfo);
        }
    }
}
