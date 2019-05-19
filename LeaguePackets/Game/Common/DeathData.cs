using System;


namespace LeaguePackets.Game.Common
{
    public class DeathData
    {
        public uint KillerNetID { get; set; }
        public uint DamageType { get; set; }
        public uint DamageSource { get; set; }
        public float DeathDuration { get; set; }
        public bool BecomeZombie { get; set; }
        public byte DeathType { get; set; }
    }

    public static class DeathDataExtension
    {
        public static DeathData ReadDeathDataPacket(this ByteReader reader)
        {
            var data = new DeathData();
            data.KillerNetID = reader.ReadUInt32();
            data.DamageType = reader.ReadUInt32();
            data.DamageSource = reader.ReadUInt32();
            data.DeathDuration = reader.ReadFloat();

            byte bitfield = reader.ReadByte();
            data.BecomeZombie = (bitfield & 1) != 0;

            data.DeathType = reader.ReadByte();
            return data;
        }

        public static void WriteDeathDataPacket(this ByteWriter writer, DeathData data)
        {
            if(data == null)
            {
                data = new DeathData();
            }

            writer.WriteUInt32(data.KillerNetID);
            writer.WriteUInt32(data.DamageType);
            writer.WriteUInt32(data.DamageSource);
            writer.WriteFloat(data.DeathDuration);

            byte bitfield = 0;
            if (data.BecomeZombie)
                bitfield |= 1;
            writer.WriteByte(bitfield);
            writer.WriteByte(data.DeathType);
        }
    }
}
