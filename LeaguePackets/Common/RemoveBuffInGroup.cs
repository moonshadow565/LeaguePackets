using System;
namespace LeaguePackets.Common
{
    public struct RemoveBuffInGroup
    {
        public NetID OwnerNetID { get; set; }
        public byte Slot { get; set; }
        public float RunTimeRemove { get; set; }
    }
}
