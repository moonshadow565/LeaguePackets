
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_RemoveDebugObject : GamePacket, IUnusedPacket // 0x58
    {
        public override GamePacketID ID => GamePacketID.S2C_RemoveDebugObject;
        public int ObjectID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ObjectID = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ObjectID);
        }
    }
}
