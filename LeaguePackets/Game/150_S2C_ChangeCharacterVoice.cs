
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
        public bool Reset { get; set; }
        public string VoiceOverride { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {
            this.Reset = reader.ReadBool();
            this.VoiceOverride = reader.ReadFixedStringLast(64);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(Reset);
            writer.WriteFixedStringLast(VoiceOverride, 64);
        }
    }
}
