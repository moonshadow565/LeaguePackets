
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetAutoAttackGroundAllowed : GamePacket // 0x101
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetAutoAttackGroundAllowed;
        public uint NetID { get; set; }
        public byte CanAutoAttackGroundState { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.CanAutoAttackGroundState = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteByte(CanAutoAttackGroundState);
        }
    }
}
