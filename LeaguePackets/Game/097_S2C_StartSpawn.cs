
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_StartSpawn : GamePacket // 0x62
    {
        public override GamePacketID ID => GamePacketID.S2C_StartSpawn;
        public byte BotCountOrder { get; set; }
        public byte BotCountChaos { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.BotCountOrder = reader.ReadByte();
            this.BotCountChaos = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(BotCountOrder);
            writer.WriteByte(BotCountChaos);
        }
    }
}
