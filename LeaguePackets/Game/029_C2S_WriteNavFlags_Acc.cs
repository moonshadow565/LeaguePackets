
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_WriteNavFlags_Acc : GamePacket // 0x1D
    {
        public override GamePacketID ID => GamePacketID.C2S_WriteNavFlags_Acc;
        public int SyncID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SyncID);
        }
    }
}
