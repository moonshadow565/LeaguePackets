using System;
namespace LeaguePackets.Common
{
    public struct ParticleFlexID
    {
        public byte ID { get; private set; }
        public static explicit operator ParticleFlexID(byte id) => new ParticleFlexID { ID = id };
        public static explicit operator byte(ParticleFlexID id) => id.ID;
        public static bool operator ==(ParticleFlexID id1, ParticleFlexID id2) => id1.ID == id2.ID;
        public static bool operator !=(ParticleFlexID id1, ParticleFlexID id2) => !(id1 == id2);
        public override bool Equals(Object obj) => (obj is ParticleFlexID id2) && this == id2;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
