using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SPM_AddListener : GamePacket, IUnusedPacket // 0x91
    {
        public override GamePacketID ID => GamePacketID.SPM_AddListener;
        public static SPM_AddListener CreateBody(PacketReader reader, NetID senderNetID) 
        {
            var result = new SPM_AddListener();
            result.SenderNetID = senderNetID;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
