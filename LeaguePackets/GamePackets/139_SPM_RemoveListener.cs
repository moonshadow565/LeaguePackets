using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_RemoveListener : GamePacket, IUnusedPacket // 0x8B
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveListener;
        public static SPM_RemoveListener CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new SPM_RemoveListener();
            result.SenderNetID = senderNetID;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
