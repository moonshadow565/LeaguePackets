
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
        public bool Hidden { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ObjectID = reader.ReadInt32();

            byte bitfield = reader.ReadByte();
            this.Hidden = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ObjectID);

            byte bitfield = 0;
            if (Hidden)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
