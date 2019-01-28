
using LeaguePackets.Game.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_NPC_Die_MapView : GamePacket // 0x126
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_Die_MapView;
        public DeathData DeathData { get; set; } = new DeathData();

        protected override void ReadBody(ByteReader reader)
        {

            this.DeathData = reader.ReadDeathDataPacket();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteDeathDataPacket(DeathData);
        }
    }
}
