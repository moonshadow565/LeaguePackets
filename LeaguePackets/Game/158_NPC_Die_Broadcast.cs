
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class NPC_Die_Broadcast : GamePacket // 0x9E
    {
        public override GamePacketID ID => GamePacketID.NPC_Die_Broadcast;
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
