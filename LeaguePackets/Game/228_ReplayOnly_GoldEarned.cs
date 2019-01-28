
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class ReplayOnly_GoldEarned : GamePacket // 0xE4
    {
        public override GamePacketID ID => GamePacketID.ReplayOnly_GoldEarned;
        public uint OwnerID { get; set; }
        public float Amount { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.OwnerID = reader.ReadUInt32();
            this.Amount = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(OwnerID);
            writer.WriteFloat(Amount);
        }
    }
}
