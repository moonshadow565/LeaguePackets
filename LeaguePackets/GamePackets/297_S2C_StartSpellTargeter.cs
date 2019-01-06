using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_StartSpellTargeter : GamePacket // 0x129
    {
        public override GamePacketID ID => GamePacketID.S2C_StartSpellTargeter;
        public byte Slot { get; set; }
        public float Unknonw1 { get; set; }
        public S2C_StartSpellTargeter(){}

        public S2C_StartSpellTargeter(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            Slot = (byte)reader.ReadUInt32();
            Unknonw1 = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32((uint)Slot);
            writer.WriteFloat(Unknonw1);
        }
    }
}
