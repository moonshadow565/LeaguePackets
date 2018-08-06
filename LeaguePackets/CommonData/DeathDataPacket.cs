using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class DeathDataPacket
    {
        public NetID KillerNetID { get; set; }
        public DamageType DamageType { get; set; }
        public DamageSource DamageSource { get; set; }
        public float DeathDuration { get; set; }
        //TODO: change to enum or variables
        public byte Bitfield { get; set; }
        //TODO: enum?
        public byte DieType { get; set; }
    }

    public static class DeathDataPacketExtension
    {
        public static DeathDataPacket ReadDeathDataPacket(this PacketReader reader)
        {
            var data = new DeathDataPacket();
            data.KillerNetID = reader.ReadNetID();
            data.DamageType = reader.ReadDamageType();
            data.DamageSource = reader.ReadDamageSource();
            data.DeathDuration = reader.ReadFloat();
            data.Bitfield = reader.ReadByte();
            data.DieType = reader.ReadByte();
            return data;
        }

        public static void WriteDeathDataPacket(this PacketWriter writer, DeathDataPacket data)
        {
            if(data == null)
            {
                data = new DeathDataPacket();
            }
            writer.WriteNetID(data.KillerNetID);
            writer.WriteDamageType(data.DamageType);
            writer.WriteDamageSource(data.DamageSource);
            writer.WriteFloat(data.DeathDuration);
            writer.WriteByte(data.Bitfield);
            writer.WriteByte(data.DieType);
        }
    }
}
