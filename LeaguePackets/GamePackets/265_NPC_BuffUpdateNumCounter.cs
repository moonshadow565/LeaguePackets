using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_BuffUpdateNumCounter : GamePacket // 0x109
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateNumCounter;
        public byte BuffSlot { get; set; }
        public int Counter { get; set; }
        public static NPC_BuffUpdateNumCounter CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new NPC_BuffUpdateNumCounter();
            result.SenderNetID = senderNetID;
            result.BuffSlot = reader.ReadByte();
            result.Counter = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteInt32(Counter);
        }
    }
}
