
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_Exit : GamePacket // 0x98
    {
        public override GamePacketID ID => GamePacketID.S2C_Exit;
        public uint NetID { get; set; }
        // Unknown1 is perhaps "IsAlly" ?
        public bool Unknown1 { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            this.Unknown1 = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            byte bitfield = 0;
            if (Unknown1)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
