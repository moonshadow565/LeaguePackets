
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetAnimStates : GamePacket // 0x6B
    {
        public override GamePacketID ID => GamePacketID.S2C_SetAnimStates;
        public Dictionary<string, string> AnimationOverrides { get; set; } = new Dictionary<string, string>();

        protected override void ReadBody(ByteReader reader)
        {

            int number = reader.ReadByte();
            for (int i = 0; i < number; i++)
            {
                var fromAnim = reader.ReadSizedString();
                var toAnim = reader.ReadSizedString();
                this.AnimationOverrides[fromAnim] = toAnim;
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            int number = AnimationOverrides.Count;
            if (number > 0xFF)
            {
                throw new IOException("AnimationOverrides list too big!");
            }
            writer.WriteByte((byte)number);
            foreach (var kvp in AnimationOverrides)
            {
                writer.WriteSizedString(kvp.Key);
                writer.WriteSizedString(kvp.Value);
            }
        }
    }
}
