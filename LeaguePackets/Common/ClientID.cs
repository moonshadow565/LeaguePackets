using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Common
{
    public struct ClientID
    {
        public uint ID { get; private set; }
        public static explicit operator ClientID(uint id) => new ClientID { ID = id };
        public static explicit operator uint(ClientID id) => id.ID;
        public static explicit operator ClientID(IntPtr id) => new ClientID { ID = (uint)id };
        public static explicit operator IntPtr(ClientID id) => (IntPtr)id.ID;
        public static explicit operator ClientID(PlayerID id) => new ClientID { ID = (uint)id.ID };
        public static explicit operator PlayerID(ClientID id) => (PlayerID)id.ID;
        public static bool operator ==(ClientID a, ClientID b) => a.ID == b.ID;
        public static bool operator !=(ClientID a, ClientID b) => !(a == b);
        public override bool Equals(Object obj) => (obj is ClientID b) && this == b;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
