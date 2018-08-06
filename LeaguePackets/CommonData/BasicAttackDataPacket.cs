using System;
using System.Numerics;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class BasicAttackDataPacket
    {
        public NetID TargetNetID { get; set; }
        public Vector3 TargetPosition { get; set; }
        public byte ExtraTime { get; set; }
        public NetID MissileNextID { get; set; }
        public byte AttackSlot { get; set; }
    }
    public static class CommonBasicAttackExtension
    {
        public static BasicAttackDataPacket ReadBasicAttackDataPacket(this PacketReader reader)
        {
            var attack = new BasicAttackDataPacket();
            attack.TargetNetID = reader.ReadNetID();
            attack.TargetPosition = reader.ReadVector3();
            attack.ExtraTime = reader.ReadByte();
            attack.MissileNextID = reader.ReadNetID();
            attack.AttackSlot = reader.ReadByte();
            return attack;
        }

        public static void WriteBasicAttackDataPacket(this PacketWriter writer, BasicAttackDataPacket attack)
        {
            if(attack == null)
            {
                attack = new BasicAttackDataPacket();
            }
            writer.WriteNetID(attack.TargetNetID);
            writer.WriteVector3(attack.TargetPosition);
            writer.WriteByte(attack.ExtraTime);
            writer.WriteNetID(attack.MissileNextID);
            writer.WriteByte(attack.AttackSlot);
        }
    }
}
