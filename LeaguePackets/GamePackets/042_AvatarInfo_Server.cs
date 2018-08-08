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

        public static AvatarInfo_Server CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new AvatarInfo_Server();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.AvatarInfo = reader.ReadAvatarInfo();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteAvatarInfo(AvatarInfo);
        }
    }
}
