using LeaguePackets.PayloadPackets;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public abstract partial class PayloadPacket
    {
        private static readonly Dictionary<PayloadPacketID, Func<PacketReader, PayloadPacket>> _lookup
        = new Dictionary<PayloadPacketID, Func<PacketReader, PayloadPacket>>
        {
            {
                PayloadPacketID.RequestJoinTeam,
                (r) => RequestJoinTeam.CreateBody(r)
            },
            {
                PayloadPacketID.RequestResking,
                (r) => RequestReskin.CreateBody(r)
            },
            {
                PayloadPacketID.RequestRename,
                (r) => RequestRename.CreateBody(r)
            },
            {
                PayloadPacketID.TeamRosterUpdate,
                (r) => TeamRosterUpdate.CreateBody(r)
            },
            {
                PayloadPacketID.Chat,
                (r) => Chat.CreateBody(r)
            },
            {
                PayloadPacketID.QuickChat,
                (r) => QuickChat.CreateBody(r)
            },
        };
    }
}
