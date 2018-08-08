using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_TeamSurrenderStatus : GamePacket // 0xA5
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamSurrenderStatus;
        public SurrenderReason Reason { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public TeamID TeamID { get; set; }
        public S2C_TeamSurrenderStatus(){}

        public S2C_TeamSurrenderStatus(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Reason = reader.ReadSurrenderReason();
            this.ForVote = reader.ReadByte();
            this.AgainstVote = reader.ReadByte();
            this.TeamID = reader.ReadTeamID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteSurrenderReason(Reason);
            writer.WriteByte(ForVote);
            writer.WriteByte(AgainstVote);
            writer.WriteTeamID(TeamID);
        }
    }
}
