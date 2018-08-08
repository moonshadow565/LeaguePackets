using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_TeamBalanceStatus : GamePacket // 0xFC
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamBalanceStatus;
        public SurrenderReason Reason { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public TeamID TeamID { get; set; }
        public float GoldGranted { get; set; }
        public int ExperienceGranted { get; set; }
        public int TowersGranted { get; set; }
        public S2C_TeamBalanceStatus(){}

        public S2C_TeamBalanceStatus(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Reason = reader.ReadSurrenderReason();
            this.ForVote = reader.ReadByte();
            this.AgainstVote = reader.ReadByte();
            this.TeamID = reader.ReadTeamID();
            this.GoldGranted = reader.ReadFloat();
            this.ExperienceGranted = reader.ReadInt32();
            this.TowersGranted = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteSurrenderReason(Reason);
            writer.WriteByte(ForVote);
            writer.WriteByte(AgainstVote);
            writer.WriteTeamID(TeamID);
            writer.WriteFloat(GoldGranted);
            writer.WriteInt32(ExperienceGranted);
            writer.WriteInt32(TowersGranted);
        }
    }
}
