
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class World_LockCamera_Server : GamePacket // 0x81
    {
        public override GamePacketID ID => GamePacketID.World_LockCamera_Server;
        public bool Locked { get; set; }
        public int ClientID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.Locked = (bitfield & 0x01) != 0;

            this.ClientID = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (Locked)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);

            writer.WriteInt32(ClientID);
        }
    }
}
