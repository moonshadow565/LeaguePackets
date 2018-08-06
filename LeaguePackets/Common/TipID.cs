using System;
namespace LeaguePackets.Common
{
    public struct TipID
    {
        public uint ID { get; private set; }
        public static explicit operator TipID(uint id) => new TipID { ID = id };
        public static explicit operator uint(TipID id) => id.ID;
        public static bool operator ==(TipID id1, TipID id2) => id1.ID == id2.ID;
        public static bool operator !=(TipID id1, TipID id2) => !(id1 == id2);
        public override bool Equals(Object obj) => (obj is TipID id2) && this == id2;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
