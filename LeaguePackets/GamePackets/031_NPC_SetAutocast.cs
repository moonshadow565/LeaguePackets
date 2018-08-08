using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_SetAutocast : GamePacket // 0x1F
    {
        public override GamePacketID ID => GamePacketID.NPC_SetAutocast;
        public byte Slot { get; set; }
        public byte CritSlot { get; set; }
        public NPC_SetAutocast(){}

        public NPC_SetAutocast(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Slot = reader.ReadByte();
            this.CritSlot = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(CritSlot);
        }
    }
}
