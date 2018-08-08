using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_MuteVolumeCategory : GamePacket // 0x27
    {
        public override GamePacketID ID => GamePacketID.S2C_MuteVolumeCategory;
        public VolumeCategoryType VolumeCategory { get; set; }
        public bool Mute { get; set; }

        public S2C_MuteVolumeCategory(){}

        public S2C_MuteVolumeCategory(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.VolumeCategory = reader.ReadVolumeCategoryType();
            byte bitfield = reader.ReadByte();
            this.Mute = (bitfield & 0x01u) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVolumeCategoryType(VolumeCategory);
            byte bitfield = 0;
            if (Mute)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
