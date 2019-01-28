
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class AttachFlexParticleS2C : GamePacket // 0xD2
    {
        public override GamePacketID ID => GamePacketID.AttachFlexParticleS2C;
        public uint NetID { get; set; }
        public byte ParticleFlexID { get; set; }
        public byte CpIndex { get; set; }
        public uint ParticleAttachType { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.ParticleFlexID = reader.ReadByte();
            this.CpIndex = reader.ReadByte();
            this.ParticleAttachType = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteByte(ParticleFlexID);
            writer.WriteByte(CpIndex);
            writer.WriteUInt32(ParticleAttachType);
        }
    }
}
