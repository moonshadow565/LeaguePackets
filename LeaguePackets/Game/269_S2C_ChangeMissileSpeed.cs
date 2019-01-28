
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ChangeMissileSpeed : GamePacket // 0x10D
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeMissileSpeed;
        public float Speed { get; set; }
        public float Delay { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Speed = reader.ReadFloat();
            this.Delay = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(Speed);
            writer.WriteFloat(Delay);
        }
    }
}
