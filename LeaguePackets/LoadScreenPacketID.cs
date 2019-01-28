using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public enum LoadScreenPacketID : byte
    {
        RequestJoinTeam = 0x64,
        RequestResking = 0x65,
        RequestRename = 0x66,
        TeamRosterUpdate = 0x67,
        Chat = 0x68,
        QuickChat = 0x69,
    }
}
