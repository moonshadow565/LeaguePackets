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
        public NPC_BuffUpdateNumCounter(){}

        public NPC_BuffUpdateNumCounter(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.BuffSlot = reader.ReadByte();
            this.Counter = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteInt32(Counter);
        }
    }
}
