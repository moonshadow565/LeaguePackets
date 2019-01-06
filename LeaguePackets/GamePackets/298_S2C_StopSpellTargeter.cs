using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_StopSpellTargeter : GamePacket // 0x12A
    {
        public override GamePacketID ID => GamePacketID.S2C_StopSpellTargeter;
        public byte Slot { get; set; }
        public S2C_StopSpellTargeter(){}

        public S2C_StopSpellTargeter(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            Slot = (byte)reader.ReadUInt32();

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32((uint)Slot);
        }
    }
}
