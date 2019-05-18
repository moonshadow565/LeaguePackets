
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_MoveMarker : GamePacket // 0x114
    {
        public override GamePacketID ID => GamePacketID.S2C_MoveMarker;
        public Vector2 Position { get; set; }
        public Vector2 Goal { get; set; }
        public float Speed { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Position = reader.ReadVector2();
            this.Goal = reader.ReadVector2();
            this.Speed = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteVector2(Goal);
            writer.WriteFloat(Speed);
        }
    }
}
