using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class AttachFlexParticleS2C : GamePacket // 0xD2
    {
        public override GamePacketID ID => GamePacketID.AttachFlexParticleS2C;
        public NetID NetID { get; set; }
        public ParticleFlexID FlexID { get; set; }
        public byte CpIndex { get; set; }
        public ParticleAttachType ParticleAttachType { get; set; }
        public AttachFlexParticleS2C(){}

        public AttachFlexParticleS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.FlexID = reader.ReadFlexID();
            this.CpIndex = reader.ReadByte();
            this.ParticleAttachType = (ParticleAttachType)reader.ReadUInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteFlexID(FlexID);
            writer.WriteByte(CpIndex);
            writer.WriteUInt32((uint)ParticleAttachType);
        }
    }
}
