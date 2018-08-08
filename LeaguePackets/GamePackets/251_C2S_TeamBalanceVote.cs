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
        public C2S_TeamBalanceVote(){}

        public C2S_TeamBalanceVote(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.VoteYes = (bitfield & 0x01) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
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
