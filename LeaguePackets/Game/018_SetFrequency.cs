
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SetFrequency : GamePacket // 0x12
    {
        public override GamePacketID ID => GamePacketID.SetFrequency;
        public float NewFrequency { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NewFrequency = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(NewFrequency);
        }
    }
}
