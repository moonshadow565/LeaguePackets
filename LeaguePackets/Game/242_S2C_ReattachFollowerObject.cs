
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ReattachFollowerObject : GamePacket // 0xF2
    {
        public override GamePacketID ID => GamePacketID.S2C_ReattachFollowerObject;
        public uint NewOwnerId { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NewOwnerId = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NewOwnerId);
        }
    }
}
