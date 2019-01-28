
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PlayVOCommand : GamePacket // 0x44
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayVOCommand;
        public uint CommandID { get; set; }
        public uint TargetID { get; set; }
        public bool HighlightPlayerIcon { get; set; }
        public bool FromPing { get; set; } 

        protected override void ReadBody(ByteReader reader)
        {

            this.CommandID = reader.ReadUInt32();
            this.TargetID = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            this.HighlightPlayerIcon = (bitfield & 0x01u) != 0x00u;
            this.FromPing = (bitfield & 0x02u) != 0x00u;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(CommandID);
            writer.WriteUInt32(TargetID);
            byte bitfield = 0;
            if (HighlightPlayerIcon)
                bitfield |= 1;
            if (FromPing)
                bitfield |= 2;
            writer.WriteByte(bitfield);
        }
    }
}
