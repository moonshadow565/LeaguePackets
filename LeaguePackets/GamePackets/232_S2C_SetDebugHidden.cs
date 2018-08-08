using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetDebugHidden : GamePacket, IUnusedPacket // 0xE8
    {
        public override GamePacketID ID => GamePacketID.S2C_SetDebugHidden;
        public int ObjectID { get; set; }
        public byte Bitfield { get; set; }
        public S2C_SetDebugHidden(){}

        public S2C_SetDebugHidden(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ObjectID = reader.ReadInt32();
            this.Bitfield = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteByte(Bitfield);
        }
    }
}
