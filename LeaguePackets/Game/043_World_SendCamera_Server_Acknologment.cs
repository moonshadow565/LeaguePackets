
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class World_SendCamera_Server_Acknologment : GamePacket // 0x2C
    {
        public override GamePacketID ID => GamePacketID.World_SendCamera_Server_Acknologment;
        public byte SyncID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(SyncID);
        }
    }
}
