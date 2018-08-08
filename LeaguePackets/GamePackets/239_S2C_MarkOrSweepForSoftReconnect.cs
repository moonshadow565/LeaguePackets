using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_MarkOrSweepForSoftReconnect : GamePacket // 0xEF
    {
        public override GamePacketID ID => GamePacketID.S2C_MarkOrSweepForSoftReconnect;
        public bool Unknown1 { get; set; }
        public bool Unknown2 { get; set; }
        public S2C_MarkOrSweepForSoftReconnect(){}

        public S2C_MarkOrSweepForSoftReconnect(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.Unknown1 = (bitfield & 1) != 0;
            this.Unknown2 = (bitfield & 2) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Unknown1)
                bitfield |= 1;
            if (Unknown2)
                bitfield |= 2;
            writer.WriteByte(bitfield);
        }
    }
}
