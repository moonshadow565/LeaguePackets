using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public interface IGamePacketsList
    {
        List<GamePacket> Packets { get; set; }
    }
}
