
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SetPARState : GamePacket // 0x93
    {
        public override GamePacketID ID => GamePacketID.SetPARState;
        public uint UnitNetID { get; set; }
        public uint PARState { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.UnitNetID = reader.ReadUInt32();
            this.PARState = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(UnitNetID);
            writer.WriteUInt32(PARState);
        }
    }
}
