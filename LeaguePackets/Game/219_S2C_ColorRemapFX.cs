
using LeaguePackets.Game.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ColorRemapFX : GamePacket // 0xDB
    {
        public override GamePacketID ID => GamePacketID.S2C_ColorRemapFX;
        public bool IsFadingIn { get; set; }
        public float FadeTime { get; set; }
        public uint TeamID { get; set; }
        public Color Color { get; set; }
        public float MaxWeight { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.IsFadingIn = reader.ReadBool();
            this.FadeTime = reader.ReadFloat();
            this.TeamID = reader.ReadUInt32();
            this.Color = reader.ReadColor();
            this.MaxWeight = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(IsFadingIn);
            writer.WriteFloat(FadeTime);
            writer.WriteUInt32(TeamID);
            writer.WriteColor(Color);
            writer.WriteFloat(MaxWeight);
        }
    }
}
