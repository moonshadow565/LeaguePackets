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
                (r, c) => RequestJoinTeam.CreateBody(r, c)
            },
            {
                PayloadPacketID.RequestResking,
                (r, c) => RequestReskin.CreateBody(r, c)
            },
            {
                PayloadPacketID.RequestRename,
                (r, c) => RequestRename.CreateBody(r, c)
            },
            {
                PayloadPacketID.TeamRosterUpdate,
                (r, c) => TeamRosterUpdate.CreateBody(r, c)
            },
            {
                PayloadPacketID.Chat,
                (r, c) => Chat.CreateBody(r, c)
            },
            {
                PayloadPacketID.QuickChat,
                (r, c) => QuickChat.CreateBody(r, c)
            },
        };
    }
}
