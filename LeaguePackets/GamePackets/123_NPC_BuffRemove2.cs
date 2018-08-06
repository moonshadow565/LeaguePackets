using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_BuffRemove2 : GamePacket // 0x7B
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffRemove2;
        public byte BuffSlot { get; set; }
        public uint BuffNameHash { get; set; }
        public float RunTimeRemove { get; set; }
        public static NPC_BuffRemove2 CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new NPC_BuffRemove2();
            result.SenderNetID = senderNetID;
            result.BuffSlot = reader.ReadByte();
            result.BuffNameHash = reader.ReadUInt32();
            result.RunTimeRemove = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteUInt32(BuffNameHash);
            writer.WriteFloat(RunTimeRemove);
        }
    }
}
