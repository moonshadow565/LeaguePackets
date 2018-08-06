using System;
namespace LeaguePackets.Common
{
    public struct ItemID
    {
        public uint ID { get; private set; }
        public static explicit operator ItemID(uint id) => new ItemID { ID = id };
        public static explicit operator uint(ItemID id) => id.ID;
        public static bool operator ==(ItemID a, ItemID b) => a.ID == b.ID;
        public static bool operator !=(ItemID a, ItemID b) => !(a == b);
        public override bool Equals(Object obj) => (obj is ItemID b) && this == b;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
