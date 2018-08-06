using System;
namespace LeaguePackets.Common
{
    public struct  PlayerID
    {
        public ulong ID { get; private set; }
        public static readonly PlayerID Invalid = new PlayerID { ID = 0xFFFFFFFFFFFFFFFFUL };
        public static explicit operator PlayerID(uint id) => new PlayerID { ID = id };
        public static explicit operator uint(PlayerID id) => (uint)id.ID;
        public static explicit operator PlayerID(ulong id) => new PlayerID { ID = id };
        public static explicit operator ulong(PlayerID id) => id.ID;
        public static bool operator ==(PlayerID id1, PlayerID id2) => (uint)id1.ID == (uint)id2.ID;
        public static bool operator !=(PlayerID id1, PlayerID id2) => !(id1 == id2);
        public override bool Equals(Object obj) => (obj is PlayerID id2) && this == id2;
        public override int GetHashCode() => ((uint)ID).GetHashCode();
    }
}
