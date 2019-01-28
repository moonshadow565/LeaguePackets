
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PlayThemeMusic : GamePacket // 0x60
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayThemeMusic;
        public uint SourceNetID { get; set; }
        public uint MusicID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SourceNetID = reader.ReadUInt32();
            this.MusicID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(SourceNetID);
            writer.WriteUInt32(MusicID);
        }
    }
}
