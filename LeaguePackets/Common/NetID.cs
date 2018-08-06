using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Common
{
    public struct NetID
    {
        public uint ID { get; private set; }
        public static explicit operator NetID (uint id) => new NetID { ID = id };
        public static explicit operator uint (NetID id) => id.ID;
        public static bool operator == (NetID id1, NetID id2) => id1.ID == id2.ID;
        public static bool operator != (NetID id1, NetID id2) => !(id1 == id2);
        public override bool Equals(Object obj) => (obj is NetID id2) && this == id2;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
