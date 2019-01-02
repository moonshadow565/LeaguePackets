using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class DeathDataPacket
    {
        public bool BecomeZombie { get; set; }
        //TODO: enum: MINION_DIE = 0x0, NETURAL_DIE = 0x1,
        public byte DieType { get; set; }
        public NetID KillerNetID { get; set; }
        public DamageType DamageType { get; set; }
        public DamageSource DamageSource { get; set; }
        public float DeathDuration { get; set; }
    }

    public static class DeathDataPacketExtension
    {
        public static DeathDataPacket ReadDeathDataPacket(this PacketReader reader)
        {
            var data = new DeathDataPacket();

            byte bitfield = reader.ReadByte();
            data.BecomeZombie = (bitfield & 1) != 0;

            data.DieType = (byte)reader.ReadUInt32();
            data.KillerNetID = reader.ReadNetID();
            data.DamageType = (DamageType)reader.ReadByte();
            data.DamageSource = (DamageSource)reader.ReadByte();
            data.DeathDuration = reader.ReadFloat();
            return data;
        }

        public static void WriteDeathDataPacket(this PacketWriter writer, DeathDataPacket data)
        {
            if(data == null)
            {
                data = new DeathDataPacket();
            }

            byte bitfield = 0;
            if(data.BecomeZombie)
            {
                bitfield |= 0x01;
            }
            writer.WriteByte(bitfield);
        
            writer.WriteUInt32((uint)data.DieType);
            writer.WriteNetID(data.KillerNetID);
            writer.WriteByte((byte)data.DamageType);
            writer.WriteByte((byte)data.DamageSource);
            writer.WriteFloat(data.DeathDuration);
        }
    }
}
