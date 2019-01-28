
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_UpdateBounceMissile : GamePacket // 0x119
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateBounceMissile;
        public uint TargetNetID { get; set; }
        public Vector3 CasterPosition { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TargetNetID = reader.ReadUInt32();
            this.CasterPosition = reader.ReadVector3();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TargetNetID);
            writer.WriteVector3(CasterPosition);
        }
    }
}
