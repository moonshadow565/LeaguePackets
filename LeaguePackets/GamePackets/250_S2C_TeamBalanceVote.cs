using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_TeamBalanceVote : GamePacket // 0xFA
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamBalanceVote;
        public bool VoteYes { get; set; }
        public bool OpenVoteMenu { get; set; }
        public NetID PlayerNetID { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public byte NumPlayers { get; set; }
        public TeamID TeamID { get; set; }
        public float TimeOut { get; set; }
        public float GoldGranted { get; set; }
        public int ExperienceGranted { get; set; }
        public int TowersGranted { get; set; }

        public static S2C_TeamBalanceVote CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_TeamBalanceVote();
            result.SenderNetID = senderNetID;
            byte bitfield = reader.ReadByte();
            result.VoteYes = (bitfield & 1) != 0;
            result.OpenVoteMenu = (bitfield & 2) != 0;
            result.PlayerNetID = reader.ReadNetID();
            result.ForVote = reader.ReadByte();
            result.AgainstVote = reader.ReadByte();
            result.NumPlayers = reader.ReadByte();
            result.TeamID = reader.ReadTeamID();
            result.TimeOut = reader.ReadFloat();
            result.GoldGranted = reader.ReadFloat();
            result.ExperienceGranted = reader.ReadInt32();
            result.TowersGranted = reader.ReadInt32();
        
            return result;
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
            writer.WriteFloat(GoldGranted);
            writer.WriteInt32(ExperienceGranted);
            writer.WriteInt32(TowersGranted);
        }
    }
}
