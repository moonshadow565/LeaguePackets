
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_TeamBalanceVote : GamePacket // 0xFA
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamBalanceVote;
        public bool VoteYes { get; set; }
        public bool OpenVoteMenu { get; set; }
        public uint PlayerNetID { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public byte NumPlayers { get; set; }
        public uint TeamID { get; set; }
        public float TimeOut { get; set; }
        public float GoldGranted { get; set; }
        public int ExperienceGranted { get; set; }
        public int TowersGranted { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.VoteYes = (bitfield & 1) != 0;
            this.OpenVoteMenu = (bitfield & 2) != 0;
            this.PlayerNetID = reader.ReadUInt32();
            this.ForVote = reader.ReadByte();
            this.AgainstVote = reader.ReadByte();
            this.NumPlayers = reader.ReadByte();
            this.TeamID = reader.ReadUInt32();
            this.TimeOut = reader.ReadFloat();
            this.GoldGranted = reader.ReadFloat();
            this.ExperienceGranted = reader.ReadInt32();
            this.TowersGranted = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (VoteYes)
                bitfield |= 1;
            if (OpenVoteMenu)
                bitfield |= 2;

            writer.WriteByte(bitfield);
            writer.WriteUInt32(PlayerNetID);
            writer.WriteByte(ForVote);
            writer.WriteByte(AgainstVote);
            writer.WriteByte(NumPlayers);
            writer.WriteUInt32(TeamID);
            writer.WriteFloat(TimeOut);
            writer.WriteFloat(GoldGranted);
            writer.WriteInt32(ExperienceGranted);
            writer.WriteInt32(TowersGranted);
        }
    }
}
