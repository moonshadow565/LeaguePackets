using System;
namespace LeaguePackets
{
    public enum ChannelID : byte
    {
        Default = 0x0,
        ClientToServer = 0x1,
        SynchClock = 0x2,
        Broadcast = 0x3,
        BroadcastUnreliable = 0x4,
        Chat = 0x5,
        QuickChat = 0x6,
        LoadingScreen = 0x7,
    }
}
