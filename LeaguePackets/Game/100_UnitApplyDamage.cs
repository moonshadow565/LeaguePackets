
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class UnitApplyDamage : GamePacket // 0x65
    {
        public override GamePacketID ID => GamePacketID.UnitApplyDamage;
        public byte DamageResultType { get; set; }
        public byte DamageType { get; set; }
        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }
        public float Damage { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.DamageResultType = (byte)(bitfield & 0x07);
            this.DamageType = (byte)((bitfield >> 3) & 0x03);

            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();
            this.Damage = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(DamageResultType & 0x07);
            bitfield |= (byte)((DamageType & 0x03) << 3);
            writer.WriteByte(bitfield);

            writer.WriteUInt32(TargetNetID);
            writer.WriteUInt32(SourceNetID);
            writer.WriteFloat(Damage);
        }
    }
}
