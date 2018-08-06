using System;
namespace LeaguePackets.Common
{
    public struct RespawnPointUIID
    {
        public byte ID { get; private set; }
        public static explicit operator RespawnPointUIID(byte id) => new RespawnPointUIID { ID = id };
        public static explicit operator byte(RespawnPointUIID id) => id.ID;
        public static explicit operator RespawnPointUIID(uint id) => new RespawnPointUIID { ID = (byte)id };
        public static explicit operator uint(RespawnPointUIID id) => id.ID;
        public static bool operator ==(RespawnPointUIID id1, RespawnPointUIID id2) => id1.ID == id2.ID;
        public static bool operator !=(RespawnPointUIID id1, RespawnPointUIID id2) => !(id1 == id2);
        public override bool Equals(Object obj) => (obj is RespawnPointUIID id2) && this == id2;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
