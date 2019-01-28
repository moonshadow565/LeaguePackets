
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetDrawPathMode : GamePacket // 0x105
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetDrawPathMode;
        public uint TargetNetID { get; set; }
        public byte DrawPathMode { get; set; }
        public float UpdateRate { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TargetNetID = reader.ReadUInt32();
            this.DrawPathMode = reader.ReadByte();
            this.UpdateRate = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TargetNetID);
            writer.WriteByte(DrawPathMode);
            writer.WriteFloat(UpdateRate);
        }
    }
}
