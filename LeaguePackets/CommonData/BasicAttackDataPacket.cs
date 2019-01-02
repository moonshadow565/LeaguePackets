using System;
using System.Numerics;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class BasicAttackDataPacket
    {
        public NetID TargetNetID { get; set; }
        public Vector3 TargetPosition { get; set; }
        public SByte ExtraTime { get; set; }
        public NetID MissileNextID { get; set; }
        public byte AttackSlot { get; set; }
    }
    public static class CommonBasicAttackExtension
    {
        public static BasicAttackDataPacket ReadBasicAttackDataPacket(this PacketReader reader)
        {
            var attack = new BasicAttackDataPacket();
            attack.TargetNetID = reader.ReadNetID();
            attack.ExtraTime = (sbyte)(reader.ReadSByte() - 128);
            attack.MissileNextID = reader.ReadNetID();
            attack.AttackSlot = reader.ReadByte();
            attack.TargetPosition = reader.ReadVector3();
            return attack;
        }

        public static void WriteBasicAttackDataPacket(this PacketWriter writer, BasicAttackDataPacket attack)
        {
            if(attack == null)
            {
                attack = new BasicAttackDataPacket();
            }
            writer.WriteNetID(attack.TargetNetID);
            writer.WriteSByte((sbyte)(attack.ExtraTime + 128));
            writer.WriteNetID(attack.MissileNextID);
            writer.WriteByte(attack.AttackSlot);
            writer.WriteVector3(attack.TargetPosition);
        }
    }
}
