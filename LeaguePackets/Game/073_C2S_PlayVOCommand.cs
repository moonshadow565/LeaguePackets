
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_PlayVOCommand : GamePacket // 0x49
    {
        public override GamePacketID ID => GamePacketID.C2S_PlayVOCommand;
        public uint CommandID { get; set; }
        public uint TargetNetID { get; set; }
        public uint EventHash { get; set; }
        public bool HighlightPlayerIcon { get; set; }
        public bool FromPing { get; set; }
        public bool AlliesOnly { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.CommandID = reader.ReadUInt32();
            this.TargetNetID = reader.ReadUInt32();
            this.EventHash = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            this.HighlightPlayerIcon = (bitfield & 1) != 0;
            this.FromPing = (bitfield & 2) != 0;
            this.AlliesOnly = (bitfield & 4) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(CommandID);
            writer.WriteUInt32(TargetNetID);
            writer.WriteUInt32(EventHash);
            byte bitfield = 0;
            if (HighlightPlayerIcon)
                bitfield |= (byte)1;
            if (FromPing)
                bitfield |= (byte)2;
            if (AlliesOnly)
                bitfield |= (byte)4;
            writer.WriteByte(bitfield);
        }
    }
}
