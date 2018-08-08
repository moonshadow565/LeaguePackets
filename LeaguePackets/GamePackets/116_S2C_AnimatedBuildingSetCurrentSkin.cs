using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_AnimatedBuildingSetCurrentSkin : GamePacket // 0x74
    {
        public override GamePacketID ID => GamePacketID.S2C_AnimatedBuildingSetCurrentSkin;
        public TeamID TeamID { get; set; } // stored as byte
        public uint SkinID { get; set; }

        public static S2C_AnimatedBuildingSetCurrentSkin CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_AnimatedBuildingSetCurrentSkin();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TeamID = (TeamID)reader.ReadByte();
            result.SkinID = reader.ReadUInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte((byte)TeamID);
            writer.WriteUInt32(SkinID);
        }
    }
}
