
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class ResumePacket : GamePacket // 0xA
    {
        public override GamePacketID ID => GamePacketID.ResumePacket;
        public int ClientID { get; set; }
        public bool Delayed { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ClientID = reader.ReadInt32();
            byte bitfield = reader.ReadByte();
            this.Delayed = (bitfield & 0x01) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
            byte bitfield = 0;
            if (Delayed)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
