
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class OnReplication_Acc : GamePacket // 0xA8
    {
        public override GamePacketID ID => GamePacketID.OnReplication_Acc;
        public uint SyncID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(SyncID);
        }
    }
}
