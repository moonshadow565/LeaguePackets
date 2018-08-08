using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PlayVOCommand : GamePacket // 0x44
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayVOCommand;
        public uint CommandID { get; set; }
        public NetID TargetID { get; set; }
        public bool HighlightPlayerIcon { get; set; }
        public bool FromPing { get; set; } 
        public static S2C_PlayVOCommand CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_PlayVOCommand();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.CommandID = reader.ReadUInt32();
            result.TargetID = reader.ReadNetID();
            byte bitfield = reader.ReadByte();
            result.HighlightPlayerIcon = (bitfield & 0x01u) != 0x00u;
            result.FromPing = (bitfield & 0x02u) != 0x00u;

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(CommandID);
            writer.WriteNetID(TargetID);
            byte bitfield = 0;
            if (HighlightPlayerIcon)
                bitfield |= 1;
            if (FromPing)
                bitfield |= 2;
            writer.WriteByte(bitfield);
        }
    }
}
