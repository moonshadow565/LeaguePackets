
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ShopItemSubstitutionSet : GamePacket // 0x11C
    {
        public override GamePacketID ID => GamePacketID.S2C_ShopItemSubstitutionSet;
        public uint OriginalItemID { get; set; }
        public uint ReplacementItemID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.OriginalItemID = reader.ReadUInt32();
            this.ReplacementItemID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(OriginalItemID);
            writer.WriteUInt32(ReplacementItemID);
        }
    }
}
