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

        public S2C_AnimatedBuildingSetCurrentSkin(){}

        public S2C_AnimatedBuildingSetCurrentSkin(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TeamID = (TeamID)reader.ReadByte();
            this.SkinID = reader.ReadUInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte((byte)TeamID);
            writer.WriteUInt32(SkinID);
        }
    }
}
