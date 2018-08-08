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
        public static S2C_TeamBalanceStatus CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_TeamBalanceStatus();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Reason = reader.ReadSurrenderReason();
            result.ForVote = reader.ReadByte();
            result.AgainstVote = reader.ReadByte();
            result.TeamID = reader.ReadTeamID();
            result.GoldGranted = reader.ReadFloat();
            result.ExperienceGranted = reader.ReadInt32();
            result.TowersGranted = reader.ReadInt32();
        
            return result;
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
