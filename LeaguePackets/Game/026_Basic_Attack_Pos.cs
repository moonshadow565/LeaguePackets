
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class Basic_Attack_Pos : GamePacket // 0x1A
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack_Pos;
        public BasicAttackData Attack { get; set; } = new BasicAttackData();
        public Vector2 Position { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Attack = reader.ReadBasicAttackDataPacket();
            this.Position = reader.ReadVector2();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteBasicAttackDataPacket(Attack);
            writer.WriteVector2(Position);
        }
    }
}
