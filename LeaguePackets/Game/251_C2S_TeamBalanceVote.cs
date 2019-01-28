
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_TeamBalanceVote : GamePacket // 0xFB
    {
        public override GamePacketID ID => GamePacketID.C2S_TeamBalanceVote;
        public bool VoteYes { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.VoteYes = (bitfield & 0x01) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (VoteYes)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
