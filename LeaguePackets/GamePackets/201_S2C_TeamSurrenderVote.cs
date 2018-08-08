using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_TeamSurrenderVote : GamePacket // 0xC9
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamSurrenderVote;
        public bool VoteYes { get; set; }
        public bool OpenVoteMenu { get; set; }

        public NetID PlayerNetID { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public byte NumPlayers { get; set; }
        public TeamID TeamID { get; set; }
        public float TimeOut { get; set; }

        public S2C_TeamSurrenderVote(){}

        public S2C_TeamSurrenderVote(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.VoteYes = (bitfield & 1) != 0;
            this.OpenVoteMenu = (bitfield & 2) != 0;

            this.PlayerNetID = reader.ReadNetID();
            this.ForVote = reader.ReadByte();
            this.AgainstVote = reader.ReadByte();
            this.NumPlayers = reader.ReadByte();
            this.TeamID = reader.ReadTeamID();
            this.TimeOut = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (VoteYes)
                bitfield |= 1;
            if (OpenVoteMenu)
                bitfield |= 2;
            writer.WriteByte(bitfield);

            writer.WriteNetID(PlayerNetID);
            writer.WriteByte(ForVote);
            writer.WriteByte(AgainstVote);
            writer.WriteByte(NumPlayers);
            writer.WriteTeamID(TeamID);
            writer.WriteFloat(TimeOut);
        }
    }
}
