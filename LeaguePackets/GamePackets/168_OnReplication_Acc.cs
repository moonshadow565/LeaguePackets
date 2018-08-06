using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class OnReplication_Acc : GamePacket // 0xA8
    {
        public override GamePacketID ID => GamePacketID.OnReplication_Acc;
        public uint SyncID { get; set; }
        public static OnReplication_Acc CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new OnReplication_Acc();
            result.SenderNetID = senderNetID;
            result.SyncID = reader.ReadUInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(SyncID);
        }
    }
}
