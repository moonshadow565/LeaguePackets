using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class ReloadScripts : GamePacket, IUnusedPacket // 0xAC
    {
        public override GamePacketID ID => GamePacketID.ReloadScripts;
        public static ReloadScripts CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new ReloadScripts();
            result.SenderNetID = senderNetID;
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
