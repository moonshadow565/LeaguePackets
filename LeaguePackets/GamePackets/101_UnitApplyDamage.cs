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
        public static UnitApplyDamage CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new UnitApplyDamage();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.DamageResultType = (DamageResultType)(bitfield & 0x07);
            result.DamageType = (DamageType)((bitfield >> 3) & 0x03);
            result.TargetNetID = reader.ReadNetID();
            result.SourceNetID = reader.ReadNetID();
            result.Damage = reader.ReadFloat();
        
            return result;
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
