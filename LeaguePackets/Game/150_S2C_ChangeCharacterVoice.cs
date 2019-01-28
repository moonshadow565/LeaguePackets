
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ChangeCharacterVoice : GamePacket // 0x96
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeCharacterVoice;
        public bool Unknown1 { get; set; } // set to default/zero? 
        public string VoiceOverride { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.Unknown1 = (bitfield) != 0;

            this.VoiceOverride = reader.ReadFixedStringLast(64);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (Unknown1)
            {
                bitfield |= 1;
            }
            writer.WriteByte(bitfield);

            writer.WriteFixedStringLast(VoiceOverride, 64);
        }
    }
}
