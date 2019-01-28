
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class Building_Die : GamePacket // 0x89
    {
        public override GamePacketID ID => GamePacketID.Building_Die;
        public uint AttackerNetID { get; set; }
        public uint LastHeroNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.AttackerNetID = reader.ReadUInt32();
            this.LastHeroNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(AttackerNetID);
            writer.WriteUInt32(LastHeroNetID);
        }
    }
}
