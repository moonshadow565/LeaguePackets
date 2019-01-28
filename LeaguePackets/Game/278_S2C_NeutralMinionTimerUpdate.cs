
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_NeutralMinionTimerUpdate : GamePacket // 0x116
    {
        public override GamePacketID ID => GamePacketID.S2C_NeutralMinionTimerUpdate;
        public int TypeHash { get; set; }
        public float Expire { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TypeHash = reader.ReadInt32();
            this.Expire = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(TypeHash);
            writer.WriteFloat(Expire);
        }
    }
}
