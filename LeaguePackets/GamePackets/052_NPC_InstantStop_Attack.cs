using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_InstantStop_Attack : GamePacket // 0x34
    {
        public override GamePacketID ID => GamePacketID.NPC_InstantStop_Attack;
        public NetID MissileNetID { get; set; }
        public bool KeepAnimating { get; set; }
        public bool DestroyMissile { get; set; }
        public bool OverrideVisibility { get; set; }
        public bool IsSummonerSpell { get; set; }
        public bool ForceDoClient { get; set; }
        public NPC_InstantStop_Attack(){}

        public NPC_InstantStop_Attack(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.MissileNetID = reader.ReadNetID();
            byte flags = reader.ReadByte();
            this.KeepAnimating = (flags & 1) != 0;
            this.DestroyMissile = (flags & 2) != 0;
            this.OverrideVisibility = (flags & 4) != 0;
            this.IsSummonerSpell = (flags & 8) != 0;
            this.ForceDoClient = (flags & 16) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(MissileNetID);
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
