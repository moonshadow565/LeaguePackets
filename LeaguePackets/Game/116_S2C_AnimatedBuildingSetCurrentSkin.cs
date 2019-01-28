
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_AnimatedBuildingSetCurrentSkin : GamePacket // 0x74
    {
        public override GamePacketID ID => GamePacketID.S2C_AnimatedBuildingSetCurrentSkin;
        public byte TeamID { get; set; }
        public uint SkinID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TeamID = reader.ReadByte();
            this.SkinID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(TeamID);
            writer.WriteUInt32(SkinID);
        }
    }
}
