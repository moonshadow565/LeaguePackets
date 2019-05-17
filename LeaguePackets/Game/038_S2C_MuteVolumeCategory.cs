
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_MuteVolumeCategory : GamePacket // 0x27
    {
        public override GamePacketID ID => GamePacketID.S2C_MuteVolumeCategory;
        public byte VolumeCategoryType { get; set; }
        public bool Mute { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.VolumeCategoryType = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.Mute = (bitfield & 0x01u) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(VolumeCategoryType);
            byte bitfield = 0;
            if (Mute)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
