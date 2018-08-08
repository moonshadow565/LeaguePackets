using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetItemCharges : GamePacket // 0xFD
    {
        public override GamePacketID ID => GamePacketID.S2C_SetItemCharges;
        public byte Slot { get; set; }
        public byte SpellCharges { get; set; }
        public S2C_SetItemCharges(){}

        public S2C_SetItemCharges(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Slot = reader.ReadByte();
            this.SpellCharges = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(SpellCharges);
        }
    }
}
