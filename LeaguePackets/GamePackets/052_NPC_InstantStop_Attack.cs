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
        public static NPC_InstantStop_Attack CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new NPC_InstantStop_Attack();
            result.SenderNetID = senderNetID;
            result.MissileNetID = reader.ReadNetID();
            byte flags = reader.ReadByte();
            result.KeepAnimating = (flags & 1) != 0;
            result.DestroyMissile = (flags & 2) != 0;
            result.OverrideVisibility = (flags & 4) != 0;
            result.IsSummonerSpell = (flags & 8) != 0;
            result.ForceDoClient = (flags & 16) != 0;
        
            return result;
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
