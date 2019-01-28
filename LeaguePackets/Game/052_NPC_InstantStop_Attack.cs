
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class NPC_InstantStop_Attack : GamePacket // 0x34
    {
        public override GamePacketID ID => GamePacketID.NPC_InstantStop_Attack;
        public uint MissileNetID { get; set; }
        public bool KeepAnimating { get; set; }
        public bool DestroyMissile { get; set; }
        public bool OverrideVisibility { get; set; }
        public bool IsSummonerSpell { get; set; }
        public bool ForceDoClient { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.MissileNetID = reader.ReadUInt32();
            byte flags = reader.ReadByte();
            this.KeepAnimating = (flags & 1) != 0;
            this.DestroyMissile = (flags & 2) != 0;
            this.OverrideVisibility = (flags & 4) != 0;
            this.IsSummonerSpell = (flags & 8) != 0;
            this.ForceDoClient = (flags & 16) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(MissileNetID);
            byte flags = 0;
            if (KeepAnimating)
                flags |= 1;
            if (DestroyMissile)
                flags |= 2;
            if (OverrideVisibility)
                flags |= 4;
            if (IsSummonerSpell)
                flags |= 8;
            if (ForceDoClient)
                flags |= 16;
            writer.WriteByte(flags);
        }
    }
}
