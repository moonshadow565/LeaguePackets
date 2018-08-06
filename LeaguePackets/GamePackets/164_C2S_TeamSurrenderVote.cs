using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_TeamSurrenderVote : GamePacket // 0xA4
    {
        public override GamePacketID ID => GamePacketID.C2S_TeamSurrenderVote;
        public bool VotedYes { get; set; }
        public static C2S_TeamSurrenderVote CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new C2S_TeamSurrenderVote();
            result.SenderNetID = senderNetID;
            byte bitfield = reader.ReadByte();
            result.VotedYes = (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (VotedYes)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
