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
        public S2C_PlayVOCommand(){}

        public S2C_PlayVOCommand(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.CommandID = reader.ReadUInt32();
            this.TargetID = reader.ReadNetID();
            byte bitfield = reader.ReadByte();
            this.HighlightPlayerIcon = (bitfield & 0x01u) != 0x00u;
            this.FromPing = (bitfield & 0x02u) != 0x00u;

            this.ExtraBytes = reader.ReadLeft();
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
