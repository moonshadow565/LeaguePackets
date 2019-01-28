using System;


namespace LeaguePackets.Game.Common
{
    public class DeathData
    {
        public bool BecomeZombie { get; set; }
        public byte DieType { get; set; }
        public uint KillerNetID { get; set; }
        public byte DamageType { get; set; }
        public byte DamageSource { get; set; }
        public float DeathDuration { get; set; }
    }

    public static class DeathDataExtension
    {
        public static DeathData ReadDeathDataPacket(this ByteReader reader)
        {
            var data = new DeathData();

            byte bitfield = reader.ReadByte();
            data.BecomeZombie = (bitfield & 1) != 0;

            data.DieType = (byte)reader.ReadUInt32();
            data.KillerNetID = reader.ReadUInt32();
            data.DamageType = reader.ReadByte();
            data.DamageSource = reader.ReadByte();
            data.DeathDuration = reader.ReadFloat();
            return data;
        }

        public static void WriteDeathDataPacket(this ByteWriter writer, DeathData data)
        {
            if(data == null)
            {
                data = new DeathData();
            }

            byte bitfield = 0;
            if(data.BecomeZombie)
            {
                bitfield |= 0x01;
            }
            writer.WriteByte(bitfield);
        
            writer.WriteUInt32((uint)data.DieType);
            writer.WriteUInt32(data.KillerNetID);
            writer.WriteByte(data.DamageType);
            writer.WriteByte(data.DamageSource);
            writer.WriteFloat(data.DeathDuration);
        }
    }
}
