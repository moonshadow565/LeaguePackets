
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_TeamSurrenderVote : GamePacket // 0xA4
    {
        public override GamePacketID ID => GamePacketID.C2S_TeamSurrenderVote;
        public bool VotedYes { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.VotedYes = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (VotedYes)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
