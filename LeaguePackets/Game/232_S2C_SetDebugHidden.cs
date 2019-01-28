
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SetDebugHidden : GamePacket, IUnusedPacket // 0xE8
    {
        public override GamePacketID ID => GamePacketID.S2C_SetDebugHidden;
        public int ObjectID { get; set; }
        public byte Bitfield { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ObjectID = reader.ReadInt32();
            this.Bitfield = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteByte(Bitfield);
        }
    }
}
