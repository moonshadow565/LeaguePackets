
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ForceCreateMissile : GamePacket // 0x6E
    {
        public override GamePacketID ID => GamePacketID.S2C_ForceCreateMissile;
        public uint MissileNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.MissileNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(MissileNetID);
        }
    }
}
