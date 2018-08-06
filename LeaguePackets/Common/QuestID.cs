using System;
namespace LeaguePackets.Common
{
    public struct QuestID
    {
        public uint ID { get; private set; }
        public static explicit operator QuestID(uint id) => new QuestID { ID = id };
        public static explicit operator uint(QuestID id) => id.ID;
        public static bool operator ==(QuestID id1, QuestID id2) => id1.ID == id2.ID;
        public static bool operator !=(QuestID id1, QuestID id2) => !(id1 == id2);
        public override bool Equals(Object obj) => (obj is QuestID id2) && this == id2;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
