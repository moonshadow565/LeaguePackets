using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class ResumePacket : GamePacket // 0xA
    {
        public override GamePacketID ID => GamePacketID.ResumePacket;
        public ClientID ClientID { get; set; }
        public bool Delayed { get; set; }
        public ResumePacket(){}

        public ResumePacket(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ClientID = reader.ReadClientID();
            byte bitfield = reader.ReadByte();
            this.Delayed = (bitfield & 0x01) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            byte bitfield = 0;
            if (Delayed)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
