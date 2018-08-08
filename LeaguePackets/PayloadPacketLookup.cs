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
        private static readonly Dictionary<PayloadPacketID, Func<PacketReader, ChannelID, PayloadPacket>> _lookup
        = new Dictionary<PayloadPacketID, Func<PacketReader, ChannelID, PayloadPacket>>
        {
            {
                PayloadPacketID.RequestJoinTeam,
                (r, c) => new RequestJoinTeam(r, c)
            },
            {
                PayloadPacketID.RequestResking,
                (r, c) => new RequestReskin(r, c)
            },
            {
                PayloadPacketID.RequestRename,
                (r, c) => new RequestRename(r, c)
            },
            {
                PayloadPacketID.TeamRosterUpdate,
                (r, c) => new TeamRosterUpdate(r, c)
            },
            {
                PayloadPacketID.Chat,
                (r, c) => new Chat(r, c)
            },
            {
                PayloadPacketID.QuickChat,
                (r, c) => new QuickChat(r, c)
            },
        };
    }
}
