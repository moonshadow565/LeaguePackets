
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class HeroReincarnateAlive : GamePacket // 0x2F
    {
        public override GamePacketID ID => GamePacketID.HeroReincarnateAlive;
        public Vector2 Position { get; set; }
        public float PARValue { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Position = reader.ReadVector2();
            this.PARValue = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteFloat(PARValue);
        }
    }
}
