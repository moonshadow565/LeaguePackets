using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_TeamBalanceVote : GamePacket // 0xFB
    {
        public override GamePacketID ID => GamePacketID.C2S_TeamBalanceVote;
        public bool VoteYes { get; set; }
        public static C2S_TeamBalanceVote CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new C2S_TeamBalanceVote();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.VoteYes = (bitfield & 0x01) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (VoteYes)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
