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

            this.DamageResultType = (DamageResultType)reader.ReadByte();
            reader.ReadPad(1);
            this.DamageType = (DamageType)reader.ReadByte();
            this.Damage = reader.ReadFloat();
            this.TargetNetID = reader.ReadNetID();
            this.SourceNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte((byte)DamageResultType);
            writer.WritePad(1);
            writer.WriteByte((byte)DamageType);
            writer.WriteFloat(Damage);
            writer.WriteNetID(TargetNetID);
            writer.WriteNetID(SourceNetID);
        }
    }
}
