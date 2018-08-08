using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UnitApplyDamage : GamePacket // 0x65
    {
        public override GamePacketID ID => GamePacketID.UnitApplyDamage;
        public DamageResultType DamageResultType { get; set; }
        public DamageType DamageType { get; set; }
        public NetID TargetNetID { get; set; }
        public NetID SourceNetID { get; set; }
        public float Damage { get; set; }
        public UnitApplyDamage(){}

        public UnitApplyDamage(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.DamageResultType = (DamageResultType)(bitfield & 0x07);
            this.DamageType = (DamageType)((bitfield >> 3) & 0x03);
            this.TargetNetID = reader.ReadNetID();
            this.SourceNetID = reader.ReadNetID();
            this.Damage = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)((byte)DamageResultType & 0x07);
            bitfield |= (byte)(((byte)DamageType & 0x03) << 3);
            writer.WriteByte(bitfield);
            writer.WriteNetID(TargetNetID);
            writer.WriteNetID(SourceNetID);
            writer.WriteFloat(Damage);
        }
    }
}
