
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PreloadCharacterData : GamePacket // 0x8A
    {
        public override GamePacketID ID => GamePacketID.S2C_PreloadCharacterData;
        public int SkinID { get; set; }
        public string SkinName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.SkinID = reader.ReadInt32();
            this.SkinName = reader.ReadFixedStringLast(64);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SkinID);
            writer.WriteFixedStringLast(SkinName, 64);
        }
    }
}
