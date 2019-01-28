
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

            this.DamageResultType = reader.ReadByte();
            reader.ReadPad(1);
            this.DamageType = reader.ReadByte();
            this.Damage = reader.ReadFloat();
            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(DamageResultType);
            writer.WritePad(1);
            writer.WriteByte(DamageType);
            writer.WriteFloat(Damage);
            writer.WriteUInt32(TargetNetID);
            writer.WriteUInt32(SourceNetID);
        }
    }
}
