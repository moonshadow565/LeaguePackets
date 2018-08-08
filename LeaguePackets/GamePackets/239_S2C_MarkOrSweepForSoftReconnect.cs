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
        public static S2C_MarkOrSweepForSoftReconnect CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_MarkOrSweepForSoftReconnect();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.Unknown1 = (bitfield & 1) != 0;
            result.Unknown2 = (bitfield & 2) != 0;
        
            return result;
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
