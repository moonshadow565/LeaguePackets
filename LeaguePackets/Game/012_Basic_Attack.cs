
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class Basic_Attack : GamePacket // 0xC
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack;
        public BasicAttackData Attack { get; set; } = new BasicAttackData();

        protected override void ReadBody(ByteReader reader)
        {

            this.Attack = reader.ReadBasicAttackDataPacket();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteBasicAttackDataPacket(Attack);
        }
    }
}
