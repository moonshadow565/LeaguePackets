
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class AvatarInfo_Server : GamePacket // 0x2A
    {
        public override GamePacketID ID => GamePacketID.AvatarInfo_Server;
        private uint[] _itemIDs = new uint[30];
        private uint[] _summonerSpellIDs = new uint[2];
        private uint[] _summonerSpellIDs2 = new uint[2];
        private Talent[] _talents = new Talent[80];
        public uint[] ItemIDs => _itemIDs;
        public uint[] SummonerIDs => _summonerSpellIDs;
        public uint[] SummonerIDs2 => _summonerSpellIDs;
        public Talent[] Talents => _talents;
        public byte Level { get; set; }
        public byte WardSkin { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            for (var i = 0; i < this.ItemIDs.Length; i++)
            {
                this.ItemIDs[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < this.SummonerIDs.Length; i++)
            {
                this.SummonerIDs[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < this.SummonerIDs2.Length; i++)
            {
                this.SummonerIDs2[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < this.Talents.Length; i++)
            {
                this.Talents[i] = reader.ReadTalent();
            }
            this.Level = reader.ReadByte();
            this.WardSkin = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            for (var i = 0; i < this.ItemIDs.Length; i++)
            {
                writer.WriteUInt32(this.ItemIDs[i]);
            }
            for (var i = 0; i < this.SummonerIDs.Length; i++)
            {
                writer.WriteUInt32(this.SummonerIDs[i]);
            }
            for (var i = 0; i < this.SummonerIDs2.Length; i++)
            {
                writer.WriteUInt32(this.SummonerIDs2[i]);
            }
            for (var i = 0; i < this.Talents.Length; i++)
            {
                writer.WriteTalent(this.Talents[i]);
            }
            writer.WriteByte(this.Level);
            writer.WriteByte(this.WardSkin);
        }
    }
}
