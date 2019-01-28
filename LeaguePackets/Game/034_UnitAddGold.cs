
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class UnitAddGold : GamePacket // 0x22
    {
        public override GamePacketID ID => GamePacketID.UnitAddGold;
        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }
        public float GoldAmmount { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();
            this.GoldAmmount = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TargetNetID);
            writer.WriteUInt32(SourceNetID);
            writer.WriteFloat(GoldAmmount);
        }
    }
}
